using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptObject/GameData")]
public class GameDataSO : ScriptableObject
{
    //? 系統
    private static int _language;//* 語言(0:中文、1:英文、2:日文)
    private static int _gameMode;//* 遊戲模式(0:故事模式、1:關卡練習、2:符卡練習)
    private static int _gameDifficulty;//* 遊戲難度(0:Easy、1:Normal、2:Hard、3:Lunatic)
    private static string _gameStage;//* 遊戲指定關卡
    private static int _gameCharacter;//* 遊戲主角(0:靈夢、1:魔理沙、2:早苗)
    private static int _gameType;//* 遊戲機體(0:靈夢A、1:靈夢B、2:魔理沙A、3:魔里沙B、4:早苗A、5:早苗B)
    public static int Language { get => _language; set { if (value > -1 && value < 3) _language = value; else _language = 0; AllEventSO.ChangeLanguageTrigger(); } }
    public static int GameMode { get => _gameMode; set { if (value > -1 && value < 3) _gameMode = value; else _gameMode = 0; } }
    public static int GameDifficulty { get => _gameDifficulty; set { if (value > -1 && value < 4) _gameDifficulty = value; else _gameDifficulty = 0; } }
    public static string GameStage { get => _gameStage; set { _gameStage = value; } }
    public static int GameCharacter { get => _gameCharacter; set { if (value > -1 && value < 3) _gameCharacter = value; else _gameCharacter = 0; } }
    public static int GameType { get => _gameType; set { if (value > -1 && value < 6) _gameType = value; else _gameType = 0; } }
    //? 遊戲內
    private static int _playerStartHP;//* 初始殘機 (故事模式:3、關卡練習:10、符卡練習:1)
    private static int _playerStartBomb;//* 初始Bomb (故事模式:3、關卡練習:3、符卡練習:0)
    private static float _playerStartPower;//* 初始攻擊力 (故事模式:1、關卡練習:1、符卡練習:5)
    private static int _playerHp;//* 殘機
    private static int _playerBomb;//* Bomb
    private static float _playerPower;//* 攻擊力  
    private static float _playerSmallHp;//* 殘機碎片(每6個碎片組成一個完整的)
    private static float _playerSmallBomb;//* Bomb碎片(每6個碎片組成一個完整的)
    private static float _playerSkillPower;//* 飽和狀態提升的攻擊力  
    private static float _playerSkill;//* 糰子總累積數量(糰子最多3顆，而一顆糰子又可分3等分，每一等分的消耗都得到一個Bomb和殘機碎片)       
    private static int _score;//* 分數
    private static int _point;//* 得點數
    private static int _graze;//* 擦彈數
    public static int PlayerStartHP { get => _playerStartHP; set { if (value >= 0 && value <= 10) _playerStartHP = value; else _playerStartHP = 0; } }
    public static int PlayerStartBomb { get => _playerStartBomb; set { if (value >= 0 && value <= 10) _playerStartBomb = value; else _playerStartBomb = 0; } }
    public static float PlayerStartPower { get => _playerStartPower; set { if (value >= 1 && value <= 5) _playerStartPower = value; else _playerStartPower = 1; } }
    public static int PlayerHp { get => _playerHp; set { if (value >= 0 && value <= 10) _playerHp = value; else _playerHp = 0; GameUiSO.ChangeHpImageTrigger(); } }
    public static int PlayerBomb { get => _playerBomb; set { if (value >= 0 && value <= 10) _playerBomb = value; else _playerBomb = 0; GameUiSO.ChangeBombImageTrigger(); } }
    public static float PlayerSmallHp { get => _playerSmallHp; set { _playerSmallHp = value; while (_playerSmallHp >= 6) { PlayerHp++; _playerSmallHp -= 6; } GameUiSO.ChangeHpImageTrigger(); } }
    public static float PlayerSmallBomb { get => _playerSmallBomb; set { _playerSmallBomb = value; while (_playerSmallBomb >= 6) { PlayerBomb++; _playerSmallBomb -= 6; } GameUiSO.ChangeBombImageTrigger(); } }
    public static float PlayerPower { get => _playerPower; set { if (value >= 1 && value <= 5) _playerPower = value; else _playerPower = 1; GameUiSO.ChangePowerTrigger(); } }
    public static float PlayerSkillPower { get => _playerSkillPower; set { _playerSkillPower = value; } }
    public static float PlayerSkill { get => _playerSkill; set { if (value < 9) _playerSkill = value; else { _playerSkill = 9; } GameUiSO.ChangeSkillImageTrigger(); } }

    public static int Score { get => _score; set { if (value < 999999999) _score = value; else _score = 999999999; GameUiSO.ChangeScoreTrigger(); } }
    public static int Point { get => _point; set { if (value < 99999) _point = value; else _point = 99999; GameUiSO.ChangePointTrigger(); } }
    public static int Graze { get => _graze; set { if (value < 9999) _graze = value; else _graze = 9999; GameUiSO.ChangeGrazeTrigger(); } }

    public static void ChangeGameType(bool t)
    {
        if (t == true)
        {
            switch (GameCharacter)
            {
                case 0: GameType = 0; break;
                case 1: GameType = 2; break;
                case 2: GameType = 4; break;
            }
        }
        else
        {
            switch (GameCharacter)
            {
                case 0: GameType = 1; break;
                case 1: GameType = 3; break;
                case 2: GameType = 5; break;
            }
        }
    }
    public static void SetPlayerValue()
    {
        switch (GameMode)
        {
            case 0:
                PlayerStartHP = 3;
                PlayerStartBomb = 3;
                PlayerStartPower = 1;
                break;
            case 1:
                PlayerStartHP = 10;
                PlayerStartBomb = 3;
                PlayerStartPower = 1;
                break;
            case 2:
                PlayerStartHP = 1;
                PlayerStartBomb = 0;
                PlayerStartPower = 5;
                break;
        }
    }
}
