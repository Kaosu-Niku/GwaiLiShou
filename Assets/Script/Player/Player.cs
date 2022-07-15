using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{
    [SerializeField] bool 不會Miss模式;//* 開啟即無敵，完全不會受傷 
    [SerializeField] bool 不會Death模式;//* 會受傷，但不會滿目瘡痍   
    [SerializeField] protected BulletPool GetPool;
    bool DontControl = false;//* 防止玩家操控
    bool IsMiss = false;//* 是否中彈(同時代表無敵時間，固定2秒)    
    bool Bombing = false;//* Bomb是否處於開啟狀態 
    bool CanSkill = true;//* 是否能使用Skill 
    bool FullMode = false;//* 是否正處於飽和模式
    [HideInInspector] public Vector3 ResetPoint = new Vector3(0, -3.5f, 0);//* 玩家重生點
    protected InputControl MyInput;
    protected AudioSource MyAudio;
    [SerializeField] protected List<AudioClip> AllClip = new List<AudioClip>();
    private void Awake()
    {
        GameRunSO.Player = this;
        MyInput = new InputControl();
        MyAudio = GetComponent<AudioSource>();
        transform.position = ResetPoint;
    }
    private void OnEnable()
    {
        MyInput.Enable();
        MyInput.Player.Shoot.performed += UseShoot;
        MyInput.Player.Bomb.performed += UseBomb;
        MyInput.Player.Skill.performed += UseSkill;
        MyInput.UI.Esc.performed += OpenStopPanel;
        GameRunSO.ForPlayerDontControlAction += ForPlayerDontControl;
        GameRunSO.PlayerMissAction += Miss;
    }
    private void OnDisable()
    {
        MyInput.Disable();
        MyInput.Player.Shoot.performed -= UseShoot;
        MyInput.Player.Bomb.performed -= UseBomb;
        MyInput.Player.Skill.performed -= UseSkill;
        MyInput.UI.Esc.performed -= OpenStopPanel;
        GameRunSO.ForPlayerDontControlAction -= ForPlayerDontControl;
        GameRunSO.PlayerMissAction -= Miss;
    }
    protected void UseShoot(InputAction.CallbackContext context)//? 射擊
    {
        if (DontControl == false || 不會Miss模式 == true)
            CustomUseShoot();
    }
    protected void UseBomb(InputAction.CallbackContext context)//? 使出Bomb
    {
        if (DontControl == false && Bombing == false || 不會Miss模式 == true)
            StartCoroutine(UseBombIEnum());
    }
    protected void UseSkill(InputAction.CallbackContext context)//? 使出技能
    {
        if (DontControl == false && CanSkill == true && GameDataSO.PlayerSkill >= 1 || 不會Miss模式 == true)
            StartCoroutine(UseSkillIEnum());
    }
    protected void OpenStopPanel(InputAction.CallbackContext context)//? 開啟暫停介面
    {
        GameRunSO.OpenStopPanelTrigger();
    }
    protected abstract void CustomUseShoot();
    protected abstract void CustomUseBomb();
    IEnumerator UseBombIEnum()
    {
        Bombing = true;
        GameDataSO.PlayerBomb--;
        CustomUseBomb();
        yield return new WaitForSeconds(5);
        Bombing = false;
    }
    IEnumerator UseSkillIEnum()
    {
        CanSkill = false;
        int s = ((int)(GameDataSO.PlayerSkill / 1));
        GameDataSO.PlayerSmallHp += s;
        GameDataSO.PlayerSmallBomb += s;
        GameDataSO.PlayerSkill -= s;
        if (s == 9)//? 飽和模式
        {
            GameDataSO.PlayerSkillPower = GameDataSO.PlayerPower;//? 在此模式期間攻擊力兩倍(另一個float變數參與傷害計算，非模式下數值都為0)
            FullMode = true;
            yield return new WaitForSeconds(10);
            CanSkill = true;
            GameDataSO.PlayerSkillPower = 0;
            if (FullMode == true)
            {

            }
            FullMode = false;
            yield break;
        }
        else
        {
            CanSkill = true;
            yield break;
        }
    }
    public void Miss()//? 受傷
    {
        StartCoroutine(MissIEnum());
    }
    IEnumerator MissIEnum()
    {
        if (IsMiss == false && 不會Miss模式 == false)
        {
            IsMiss = true;
            yield return new WaitForSeconds(0.2f);
            if (Bombing == false)//? 在0.2秒後確認沒有保持Bomb開啟狀態就判定以下
            {
                if (FullMode == false)//? 沒有飽和模式就Miss
                {
                    //? BIU演出時間
                    ForPlayerDontControl(true);
                    //MyAudio.clip = AllClip[0]; MyAudio.Play();
                    yield return new WaitForSeconds(1);
                    transform.position = ResetPoint;
                    GameDataSO.PlayerHp -= 1;
                    GameDataSO.PlayerBomb = 3;
                    GameDataSO.PlayerPower -= 0.5f;
                    ForPlayerDontControl(false);
                    GameRunSO.PlayerMissClearBulletTrigger();
                }
                else//? 有飽和模式就解除增攻效果、清除場上彈幕、解除飽和模式
                {
                    GameDataSO.PlayerSkillPower = 0;
                    GameRunSO.PlayerMissClearBulletTrigger();
                    FullMode = false;
                }
            }
            yield return 0;
            if (GameDataSO.PlayerHp == 0 && 不會Death模式 == false)
                Death();
            yield return new WaitForSeconds(2.8f);
            IsMiss = false;
        }
        else
            yield break;
    }
    public void Death()//? 死亡
    {
        StartCoroutine(DeathIEnum());
    }
    IEnumerator DeathIEnum()
    {
        if (不會Miss模式 == false)
        {
            DontControl = true;
            yield return new WaitForSeconds(1);
            GameRunSO.OpenDeathPanelTrigger();
            yield break;
        }
        else
            yield break;
    }
    private void ForPlayerDontControl(bool f)
    {
        if (f == false)
            DontControl = false;
        else
            DontControl = true;
    }
    protected void FixedUpdate()
    {
        //? 正常和慢速移動
        if (DontControl == false || 不會Miss模式 == true)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)
            {
                if (MyInput.Player.Up.ReadValue<float>() == 1)
                    transform.Translate(0, 2.5f * Time.deltaTime, 0);
                if (MyInput.Player.Down.ReadValue<float>() == 1)
                    transform.Translate(0, -2.5f * Time.deltaTime, 0);
                if (MyInput.Player.Left.ReadValue<float>() == 1)
                    transform.Translate(-2.5f * Time.deltaTime, 0, 0);
                if (MyInput.Player.Right.ReadValue<float>() == 1)
                    transform.Translate(2.5f * Time.deltaTime, 0, 0);
            }
            else
            {
                if (MyInput.Player.Up.ReadValue<float>() == 1)
                    transform.Translate(0, 5 * Time.deltaTime, 0);
                if (MyInput.Player.Down.ReadValue<float>() == 1)
                    transform.Translate(0, -5 * Time.deltaTime, 0);
                if (MyInput.Player.Left.ReadValue<float>() == 1)
                    transform.Translate(-5 * Time.deltaTime, 0, 0);
                if (MyInput.Player.Right.ReadValue<float>() == 1)
                    transform.Translate(5 * Time.deltaTime, 0, 0);
            }
        }
    }


}
