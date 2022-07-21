using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRun : MonoBehaviour
{
    [SerializeField] AudioClip FirstMusic;
    [SerializeField] List<Player> AllPlayer = new List<Player>();//? 根據選項生成對應機體
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;//* 關閉垂直同步
        Application.targetFrameRate = 60;//* 固定幀數
        GameDataSO.PlayerHp = GameDataSO.PlayerStartHP;
        GameDataSO.PlayerBomb = GameDataSO.PlayerStartBomb;
        GameDataSO.PlayerPower = GameDataSO.PlayerStartPower;
        GameDataSO.Score = 0;
        GameDataSO.Point = 0;
        GameDataSO.Graze = 0;
        //! Instantiate(AllPlayer[GameDataSO.GameType]);
        GameRunSO.ChangeMusicTrigger(FirstMusic);
    }
}
