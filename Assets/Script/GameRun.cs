using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRun : MonoBehaviour
{
    [SerializeField] AudioClip FirstMusic;
    [SerializeField] List<Player> AllPlayer = new List<Player>();//? 根據選項生成對應機體
    [SerializeField] List<GameObject> AllEnemy = new List<GameObject>();//? 所有生成的敵人
    [SerializeField] List<float> AllEnemyTime = new List<float>();//? 所有生成敵人的對應時間
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
        StartCoroutine(AllEnemyInstantiate());
    }
    IEnumerator AllEnemyInstantiate()
    {
        if (AllEnemy.Count > 0)
        {
            yield return new WaitForSeconds(AllEnemyTime[0]);
            Instantiate(AllEnemy[0]);
        }
        else
            yield break;
        yield return 0;
        for (int x = 1; x < AllEnemy.Count; x++)
        {
            yield return new WaitForSeconds(AllEnemyTime[x] - AllEnemyTime[x - 1]);
            Instantiate(AllEnemy[x]);
        }
        yield break;
    }
}
