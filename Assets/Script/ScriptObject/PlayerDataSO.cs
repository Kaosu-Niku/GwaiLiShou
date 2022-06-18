using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Timers;

[CreateAssetMenu(fileName = "PlayerData", menuName = "東方怪力獸/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    //? 玩家存檔記錄
    public static List<string> PlayerName = new List<string>();//? 玩家名稱(通關後輸入)
    public static List<System.DateTime> ClearDate = new List<System.DateTime>();//? 通關日期
    void 紀錄當前日期()
    {
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string a = "" + currentTime.Year + "/" + currentTime.Month + "/" + currentTime.Day;
    }
    public static List<float> ClearTime = new List<float>();//? 通關耗時
    public static List<int> ClearCharacter = new List<int>();//? 使用機體
    public static List<int> ClearMode = new List<int>();//? 難度
    public static List<int> ClearStage = new List<int>();//? 當前階層(死在一面就是顯示ST1，死在六面就是顯示ST6，全通關就是顯示ALL)
    public static List<int> ClearScore = new List<int>();//? 總分數
    public static List<int> ClearGraze = new List<int>();//? 擦彈數    
    public static List<int> ClearGetHp = new List<int>();//? 總計獲得殘機數
    public static List<int> ClearMiss = new List<int>();//? 被彈數
    public static List<int> ClearGetBomb = new List<int>();//? 總計獲得Bomb數
    public static List<int> ClearUseBomb = new List<int>();//? 總計使用Bomb數
    public static List<int> ClearSkillCount = new List<int>();//? 技能總使用次數
    public static List<float> ClearSkillGreen = new List<float>();//? 綠糰子使用次數
    public static List<float> ClearSkillRed = new List<float>();//? 紅糰子使用次數
    public static List<float> ClearSkillWrite = new List<float>();//? 白糰子使用次數
    public static List<int> ClearSkillFull = new List<int>();//? 飽和狀態使用次數


    //?(一次性紀錄)
    //? 各機體各難度通關紀錄
    public static bool[] Reimu_A_Clear = new bool[6];
    public static bool[] Reimu_B_Clear = new bool[6];
    public static bool[] Marisa_A_Clear = new bool[6];
    public static bool[] Marisa_B_Clear = new bool[6];
    public static bool[] Sanae_A_Clear = new bool[6];
    public static bool[] Sanae_B_Clear = new bool[6];
    //?音樂開放
    public static bool[] AllMusic = new bool[20];
}
