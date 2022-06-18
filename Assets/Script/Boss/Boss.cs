using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    [SerializeField] int 指定回合;
    bool 可以跳過 = false;
    [SerializeField] string BossChineseName;//* Boss中文名稱
    [SerializeField] string BossEnglishName;//* Boss英文名稱
    [SerializeField] string BossJapaneseName;//* Boss日文名稱
    [SerializeField] List<float> Hp = new List<float>();//* 血量
    float MaxHp;//* 當回合的總血量(用於血條UI計算)
    [SerializeField] List<string> CardChineseName = new List<string>();//* 符卡中文名稱
    [SerializeField] List<string> CardEnglishName = new List<string>();//* 符卡英文名稱
    [SerializeField] List<string> CardJapaneseName = new List<string>();//* 符卡日文名稱
    [SerializeField] List<float> LimitTime = new List<float>();//* 限制時間
    [SerializeField] List<int> KillScore = new List<int>();//* 擊破分數
    [SerializeField] protected List<GameObject> Bullet = new List<GameObject>();//* 子彈    
    protected int Round = 0;//* 回合數
    protected bool NotHurt = false;//* 防止受傷(時符可開啟)         
    bool IsDeath = false;//* 是否死亡
    protected Vector3 Reset = new Vector3(0, 3, 0);//* 重置點
    protected List<Coroutine> NowAction = new List<Coroutine>();//* 所有正在執行的行動
    BossTalk BossTalk;//* Boss的對話系統
    protected Player GetPlayer;//* 控制玩家
    protected AudioSource Audio;
    [SerializeField] protected List<AudioClip> AllClip = new List<AudioClip>();
    private void Awake()
    {
        BossTalk = GetComponent<BossTalk>(); Round = 指定回合;
        Audio = GetComponent<AudioSource>();
        transform.position = Reset;
        GameRunSO.OpenAllBossUITrigger();
        StartCoroutine(ResetRound());
        GetPlayer = GameRunSO.Player.GetComponent<Player>();
    }
    private void OnEnable()
    {
        GameRunSO.AllEnemy.Add(this.gameObject);
        AllEventSO.ChangeLanguageEvent += ChangeBossNameText;
        AllEventSO.ChangeLanguageEvent += ChangeCardNameText;
    }
    private void OnDisable()
    {
        GameRunSO.AllEnemy.Remove(this.gameObject);
        AllEventSO.ChangeLanguageEvent -= ChangeBossNameText;
        AllEventSO.ChangeLanguageEvent -= ChangeCardNameText;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        { //? 測試用，自動消除boss一條血
            LimitTime[Round] = 0;
        }
    }
    protected virtual void NewRoundFirst() { }//? 一更新回合馬上就要做的事
    protected virtual IEnumerator NewRoundAction()//? 更新回合後的持續行動
    {
        switch (Round)
        {
            case 0:
                //? 第一回合做的事
                break;
            case 1:
                //? 第二回合做的事
                break;
        }
        yield break;
    }
    IEnumerator ResetRound()
    {
        while (true)
        {
            可以跳過 = false;
            NewRoundFirst();
            NotHurt = true;
            MaxHp = Hp[Round];
            ChangeCardNameText();
            for (float t = 0; t < 3; t += Time.deltaTime)//? 3秒準備時間、3秒後解除無敵並開始正式行動
            {
                transform.position = Vector3.Lerp(transform.position, Reset, 5 * UnityEngine.Time.deltaTime);
                GameRunSO.ChangeCardTimeTextTrigger(((int)(LimitTime[Round] - t)));
                yield return 0;
            }
            NotHurt = false;
            if (Round == Hp.Count - 1)
                GameRunSO.ChangeBossHpSliderTrigger(0, Hp[Round] / MaxHp);
            else if (Round % 2 == 0)
                GameRunSO.ChangeBossHpSliderTrigger(Hp[Round] / MaxHp, 1);
            else
                GameRunSO.ChangeBossHpSliderTrigger(0, Hp[Round] / MaxHp);
            StartCoroutine(NewRoundAction());//? 開始新的回合的行動
            可以跳過 = true;
            for (float t = 3; t < LimitTime[Round]; t += Time.deltaTime)
            {
                GameRunSO.ChangeCardTimeTextTrigger(((int)(LimitTime[Round] - t)));
                yield return 0;
            }
            //? 本體角度歸正、增加分數、刪除所有敵方彈幕、停止並清除前一回合所有行動、確認是否已擊破、增加回合數。
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GameDataSO.Score += KillScore[Round];
            GameRunSO.BossDeathClearBulletTrigger();
            foreach (Coroutine c in NowAction)
                StopCoroutine(c);
            NowAction.Clear();
            if (Round + 1 >= Hp.Count)//? 完全擊破Boss
            {
                Death();
                yield break;
            }
            Round++;
            yield return 0;
        }
    }
    public void Hurt(float damage)//? 受傷
    {
        if (NotHurt == false)
        {
            Hp[Round] -= damage; Debug.Log(Hp[Round]);
            if (Round == Hp.Count - 1)//? 更新扣血後的血條
                GameRunSO.ChangeBossHpSliderTrigger(0, Hp[Round] / MaxHp);
            else if (Round % 2 == 0)
                GameRunSO.ChangeBossHpSliderTrigger(Hp[Round] / MaxHp, 1);
            else
                GameRunSO.ChangeBossHpSliderTrigger(0, Hp[Round] / MaxHp);
            if (Hp[Round] < 0)
                LimitTime[Round] = 0;
        }
    }
    void Death()
    {
        StartCoroutine(DeathIEnum());
    }
    IEnumerator DeathIEnum()//? 死亡
    {
        IsDeath = true;
        GameRunSO.CloseAllBossUITrigger();
        yield return new WaitForSeconds(2);
        BossTalk.enabled = true;
        GameRunSO.ForPlayerDontControlTrigger(true);
        yield return 0;
        Destroy(this);
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameRunSO.PlayerMissTrigger();
    }
    private void ChangeBossNameText()
    {
        switch (GameDataSO.Language)
        {
            case 0: GameRunSO.ChangeBossNameTextTrigger(BossChineseName); break;
            case 1: GameRunSO.ChangeBossNameTextTrigger(BossEnglishName); break;
            case 2: GameRunSO.ChangeBossNameTextTrigger(BossJapaneseName); break;
        }
    }
    private void ChangeCardNameText()
    {
        switch (GameDataSO.Language)
        {
            case 0: GameRunSO.ChangeCardNameTextTrigger(CardChineseName[Round]); break;
            case 1: GameRunSO.ChangeCardNameTextTrigger(CardEnglishName[Round]); break;
            case 2: GameRunSO.ChangeCardNameTextTrigger(CardJapaneseName[Round]); break;
        }
    }
}
