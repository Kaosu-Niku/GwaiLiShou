using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameUi", menuName = "ScriptObject/GameUi")]
public class GameUiSO : ScriptableObject
{
    public static UnityAction ChangeScoreAction;//?改變分數事件
    public static void ChangeScoreTrigger()
    {
        ChangeScoreAction?.Invoke();
    }
    public static UnityAction ChangePowerAction;//?改變攻擊力事件
    public static void ChangePowerTrigger()
    {
        ChangePowerAction?.Invoke();
    }
    public static UnityAction ChangePointAction;//?改變得點數事件
    public static void ChangePointTrigger()
    {
        ChangePointAction?.Invoke();
    }
    public static UnityAction ChangeGrazeAction;//?改變擦彈數事件
    public static void ChangeGrazeTrigger()
    {
        ChangeGrazeAction?.Invoke();
    }
    public static UnityAction ChangeHpImageAction;//?改變血量數量事件
    public static void ChangeHpImageTrigger()
    {
        ChangeHpImageAction?.Invoke();
    }
    public static UnityAction ChangeBombImageAction;//?改變Bomb數量事件
    public static void ChangeBombImageTrigger()
    {
        ChangeBombImageAction?.Invoke();
    }
    public static UnityAction ChangeSkillImageAction;//?改變糰子數量事件
    public static void ChangeSkillImageTrigger()
    {
        ChangeSkillImageAction?.Invoke();
    }
    public static UnityAction OpenStopPanelAction;//? 開啟暫停選單事件
    public static void OpenStopPanelTrigger()
    {
        OpenStopPanelAction?.Invoke();
    }
    public static UnityAction OpenDeathPanelAction;//? 開啟死亡選單事件
    public static void OpenDeathPanelTrigger()
    {
        OpenDeathPanelAction?.Invoke();
    }
    public static UnityAction<bool, string> UseTalkPanelAction;//? 使用對話框事件  
    public static void UseTalkPanelTrigger(bool u, string t)
    {
        UseTalkPanelAction?.Invoke(u, t);
    }
    public static UnityAction OpenAllBossUIAction;//? 開啟所有BOSS的UI事件
    public static void OpenAllBossUITrigger()
    {
        OpenAllBossUIAction?.Invoke();
    }
    public static UnityAction CloseAllBossUIAction;//? 關閉所有BOSS的UI事件
    public static void CloseAllBossUITrigger()
    {
        CloseAllBossUIAction?.Invoke();
    }
    public static UnityAction<string> ChangeBossNameTextAction;//?改變BOSS名字事件
    public static void ChangeBossNameTextTrigger(string s)
    {
        ChangeBossNameTextAction?.Invoke(s);
    }
    public static UnityAction<string> ChangeCardNameTextAction;//?改變符卡名字事件
    public static void ChangeCardNameTextTrigger(string s)
    {
        ChangeCardNameTextAction?.Invoke(s);
    }
    public static UnityAction<int> ChangeCardTimeTextAction;//?改變符卡時間事件
    public static void ChangeCardTimeTextTrigger(int t)
    {
        ChangeCardTimeTextAction?.Invoke(t);
    }
    public static UnityAction<float, float> ChangeBossHpSliderAction;//?改變BOSS血條事件
    public static void ChangeBossHpSliderTrigger(float hp1, float hp2)
    {
        ChangeBossHpSliderAction?.Invoke(hp1, hp2);
    }
}
