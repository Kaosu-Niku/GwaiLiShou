using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameRun", menuName = "ScriptObject/GameRun")]
public class GameRunSO : ScriptableObject
{
    public static GameObject Player;//? 玩家
    public static List<GameObject> AllEnemy = new List<GameObject>();//? 所有敵人
    public static GameObject FirstEnemy;//? 優先敵人
    public static UnityAction PlayerMissClearBulletAction;//? 玩家MISS後清除場上彈幕事件(所有需消除的彈幕需訂閱)
    public static UnityAction BossDeathClearBulletAction;//? 清除BOSS一條血清除彈幕清除場上彈幕事件(所有敵方彈幕需訂閱)
    public static UnityAction<Transform> PlayerTouchAutoGetPropAction;//? 玩家觸碰到道具收取線事件(所有道具需訂閱)      
    public static UnityAction<bool> ForPlayerDontControlAction;//? 使玩家不能控制事件
    public static UnityAction PlayerMissAction;//?玩家Miss事件
    public static UnityAction ChangeScoreAction;//?改變分數事件
    public static UnityAction ChangePowerAction;//?改變攻擊力事件
    public static UnityAction ChangePointAction;//?改變得點數事件
    public static UnityAction ChangeGrazeAction;//?改變擦彈數事件
    public static UnityAction ChangeHpImageAction;//?改變血量數量事件
    public static UnityAction ChangeBombImageAction;//?改變Bomb數量事件
    public static UnityAction ChangeSkillImageAction;//?改變糰子數量事件
    public static UnityAction OpenStopPanelAction;//? 開啟暫停選單事件
    public static UnityAction OpenDeathPanelAction;//? 開啟死亡選單事件
    public static UnityAction<bool, string> UseTalkPanelAction;//? 使用對話框事件  
    public static UnityAction OpenAllBossUIAction;//? 開啟所有BOSS的UI事件
    public static UnityAction CloseAllBossUIAction;//? 關閉所有BOSS的UI事件
    public static UnityAction<string> ChangeBossNameTextAction;//?改變BOSS名字事件
    public static UnityAction<string> ChangeCardNameTextAction;//?改變符卡名字事件
    public static UnityAction<int> ChangeCardTimeTextAction;//?改變符卡時間事件
    public static UnityAction<float, float> ChangeBossHpSliderAction;//?改變BOSS血條事件
    public static UnityAction<AudioClip> ChangeMusicAction;//? 改變音樂事件         


    public static void PlayerMissClearBulletTrigger()//? 玩家MISS清除彈幕
    {
        if (PlayerMissClearBulletAction != null)
            PlayerMissClearBulletAction.Invoke();
    }
    public static void BossDeathClearBulletTrigger()//? 清除BOSS一條血清除彈幕
    {
        if (BossDeathClearBulletAction != null)
            BossDeathClearBulletAction.Invoke();
    }
    public static void PlayerTouchAutoGetPropTrigger(Transform t)//? 玩家碰到道具收取線
    {
        if (PlayerTouchAutoGetPropAction != null)
            PlayerTouchAutoGetPropAction.Invoke(t);
    }
    public static GameObject GetFirstEnemy()//? 取得距離玩家最近的敵人
    {
        float dis = 100;
        foreach (GameObject e in AllEnemy)
        {
            if (Vector3.Distance(Player.transform.position, e.transform.position) < dis)
            {
                dis = Vector3.Distance(Player.transform.position, e.transform.position);
                FirstEnemy = e;
            }
        }
        return FirstEnemy;
    }
    public static void ForPlayerDontControlTrigger(bool f)
    {
        if (ForPlayerDontControlAction != null)
            ForPlayerDontControlAction.Invoke(f);
    }
    public static void PlayerMissTrigger()
    {
        if (PlayerMissAction != null)
            PlayerMissAction.Invoke();
    }
    public static void ChangeScoreTrigger()
    {
        if (ChangeScoreAction != null)
            ChangeScoreAction.Invoke();
    }
    public static void ChangePowerTrigger()
    {
        if (ChangePowerAction != null)
            ChangePowerAction.Invoke();
    }
    public static void ChangePointTrigger()
    {
        if (ChangePointAction != null)
            ChangePointAction.Invoke();
    }
    public static void ChangeGrazeTrigger()
    {
        if (ChangeGrazeAction != null)
            ChangeGrazeAction.Invoke();
    }
    public static void ChangeHpImageTrigger()
    {
        if (ChangeHpImageAction != null)
            ChangeHpImageAction.Invoke();
    }
    public static void ChangeBombImageTrigger()
    {
        if (ChangeBombImageAction != null)
            ChangeBombImageAction.Invoke();
    }
    public static void ChangeSkillImageTrigger()
    {
        if (ChangeSkillImageAction != null)
            ChangeSkillImageAction.Invoke();
    }
    public static void OpenStopPanelTrigger()
    {
        if (OpenStopPanelAction != null)
            OpenStopPanelAction.Invoke();
    }
    public static void OpenDeathPanelTrigger()
    {
        if (OpenDeathPanelAction != null)
            OpenDeathPanelAction.Invoke();
    }
    public static void UseTalkPanelTrigger(bool u, string t)
    {
        if (UseTalkPanelAction != null)
            UseTalkPanelAction.Invoke(u, t);
    }
    public static void OpenAllBossUITrigger()
    {
        if (OpenAllBossUIAction != null)
            OpenAllBossUIAction.Invoke();
    }
    public static void CloseAllBossUITrigger()
    {
        if (CloseAllBossUIAction != null)
            CloseAllBossUIAction.Invoke();
    }
    public static void ChangeBossNameTextTrigger(string s)
    {
        if (ChangeBossNameTextAction != null)
            ChangeBossNameTextAction.Invoke(s);
    }
    public static void ChangeCardNameTextTrigger(string s)
    {
        if (ChangeCardNameTextAction != null)
            ChangeCardNameTextAction.Invoke(s);
    }
    public static void ChangeCardTimeTextTrigger(int t)
    {
        if (ChangeCardTimeTextAction != null)
            ChangeCardTimeTextAction.Invoke(t);
    }
    public static void ChangeBossHpSliderTrigger(float hp1, float hp2)
    {
        if (ChangeBossHpSliderAction != null)
            ChangeBossHpSliderAction.Invoke(hp1, hp2);
    }
    public static void ChangeMusicTrigger(AudioClip c)
    {
        if (ChangeMusicAction != null)
            ChangeMusicAction.Invoke(c);
    }
}
