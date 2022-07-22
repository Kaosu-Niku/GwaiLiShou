using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Boss : Enemy
{
    [SerializeField] protected BulletPool GetPool;
    [SerializeField] protected List<GameObject> Bullet = new List<GameObject>();//* 子彈   


    [SerializeField] int 指定回合;
    bool 可以跳過 = false;
    [SerializeField] string BossChineseName;//* Boss中文名稱
    [SerializeField] string BossEnglishName;//* Boss英文名稱
    [SerializeField] string BossJapaneseName;//* Boss日文名稱
    [System.Serializable]
    public class BossStage//* 敵人的各階段的設置
    {
        public float Hp;//* 該階段的血量
        public float LimitTime;//* 該階段的限制時間
        public int KillScore;//* 該階段的擊破分數
        public string CardChineseName;//* 該階段的符卡中文名稱
        public string CardEnglishName;//* 該階段的符卡英文名稱
        public string CardJapaneseName;//* 該階段的符卡日文名稱
    }
    [SerializeField] List<BossStage> AllBossStage = new List<BossStage>();
    protected int Stage = 0;//* 第幾階段
    float MaxHp;//* 當回合的總血量(用於血條UI計算)
    protected bool NotHurt = false;//* 防止受傷(時符可開啟)         
    bool IsDeath = false;//* 是否死亡
    protected Vector3 Reset = new Vector3(0, 3, 0);//* 重置點
    BossTalk BossTalk;//* Boss的對話系統

    protected abstract void BossResetAction();//* 一更新回合馬上就要做的事(同時必須調用AddBossStartAction()指派接下來要執行的所有行動)
    private List<IEnumerator> BossStartAction = new List<IEnumerator>();//* 敵人自定義行動，第一次行動由enemy調用，第二次以後皆由boss調用
    protected void AddBossStartAction(IEnumerator e)
    {
        BossStartAction.Add(e);
    }
    Queue<Coroutine> NowAction = new Queue<Coroutine>();//* 所有正在執行的行動
    protected override IEnumerator CustomAction()
    {
        可以跳過 = false;
        NotHurt = true;
        MaxHp = AllBossStage[Stage].Hp;
        ChangeHpUi();
        ChangeCardNameText();
        BossResetAction();
        for (float t = 0; t < 3; t += Time.deltaTime)//? 3秒準備時間、3秒後開始正式行動
        {
            transform.position = Vector3.Lerp(transform.position, Reset, 5 * UnityEngine.Time.deltaTime);
            GameUiSO.ChangeCardTimeTextTrigger(((int)(AllBossStage[Stage].LimitTime - t)));
            yield return 0;
        }
        可以跳過 = true;
        NotHurt = false;
        for (int x = 0; x < BossStartAction.Count; x++)
        {
            NowAction.Enqueue(StartCoroutine(BossStartAction[x]));
        }
        BossStartAction.Clear();
        for (float t = 3; t < AllBossStage[Stage].LimitTime; t += Time.deltaTime)
        {
            GameUiSO.ChangeCardTimeTextTrigger(((int)(AllBossStage[Stage].LimitTime - t)));
            yield return 0;
        }
        //? enemy的邏輯，當前行動協程結束時會自動執行Clear()
    }

    protected override void Hurt(float damage)//? 受傷
    {
        if (NotHurt == false)
        {
            AllBossStage[Stage].Hp -= damage; Debug.Log(AllBossStage[Stage].Hp);
            ChangeHpUi();
            if (AllBossStage[Stage].Hp < 0)
            {
                AllBossStage[Stage].LimitTime = 0;//? 將時間歸零會自動執行clear()
            }
        }
    }
    protected override void Clear()
    {
        //? 停止所有當前階段行動、執行敵人清除事件、增加得分、確認是否已擊破。
        while (NowAction.Count > 0)
        {
            StopCoroutine(NowAction.Dequeue());
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GameRunSO.BossDeathClearBulletTrigger();
        GameDataSO.Score += AllBossStage[Stage].KillScore;
        if (Stage + 1 < AllBossStage.Count)//? 還未擊破BOSS
        {
            Stage++;
            StartCoroutine(StartAction());
        }
        else//? 完全擊破Boss
        {
            Death();
        }
    }
    void Death()
    {
        StartCoroutine(DeathIEnum());
    }
    IEnumerator DeathIEnum()//? 死亡
    {
        IsDeath = true;
        GameUiSO.CloseAllBossUITrigger();
        yield return new WaitForSeconds(2);
        BossTalk.enabled = true;
        GameRunSO.ForPlayerDontControlTrigger(true);
        yield return 0;
        this.enabled = false;
    }
    new void Awake()
    {
        base.Awake();
        BossTalk = GetComponent<BossTalk>(); Stage = 指定回合;
        transform.position = Reset;

    }
    new void OnEnable()
    {
        base.OnEnable();
        GameUiSO.OpenAllBossUITrigger();

        AllEventSO.ChangeLanguageEvent += ChangeBossNameText;
        AllEventSO.ChangeLanguageEvent += ChangeCardNameText;
    }
    new void OnDisable()
    {
        base.OnDisable();
        GameUiSO.CloseAllBossUITrigger();
        AllEventSO.ChangeLanguageEvent -= ChangeBossNameText;
        AllEventSO.ChangeLanguageEvent -= ChangeCardNameText;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        { //? 測試用，自動消除boss一條血
            AllBossStage[Stage].LimitTime = 0;
        }
    }
    private void ChangeHpUi()//? 更新扣血後的血條
    {

        if (Stage == AllBossStage.Count - 1)
            GameUiSO.ChangeBossHpSliderTrigger(0, AllBossStage[Stage].Hp / MaxHp);
        else if (Stage % 2 == 0)
            GameUiSO.ChangeBossHpSliderTrigger(AllBossStage[Stage].Hp / MaxHp, 1);
        else
            GameUiSO.ChangeBossHpSliderTrigger(0, AllBossStage[Stage].Hp / MaxHp);
    }
    private void ChangeBossNameText()
    {
        switch (GameDataSO.Language)
        {
            case 0: GameUiSO.ChangeBossNameTextTrigger(BossChineseName); break;
            case 1: GameUiSO.ChangeBossNameTextTrigger(BossEnglishName); break;
            case 2: GameUiSO.ChangeBossNameTextTrigger(BossJapaneseName); break;
        }
    }
    private void ChangeCardNameText()
    {
        switch (GameDataSO.Language)
        {
            case 0: GameUiSO.ChangeCardNameTextTrigger(AllBossStage[Stage].CardChineseName); break;
            case 1: GameUiSO.ChangeCardNameTextTrigger(AllBossStage[Stage].CardEnglishName); break;
            case 2: GameUiSO.ChangeCardNameTextTrigger(AllBossStage[Stage].CardJapaneseName); break;
        }
    }
}
