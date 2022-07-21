using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameRun", menuName = "ScriptObject/GameRun")]
public class GameRunSO : ScriptableObject
{
    public static Player Player;//? 玩家
    public static List<GameObject> AllEnemy = new List<GameObject>();//? 所有敵人
    public static GameObject FirstEnemy;//? 優先敵人
    public static UnityAction PlayerMissAction;//?玩家Miss事件
    public static void PlayerMissTrigger()
    {
        PlayerMissAction?.Invoke();
    }
    public static UnityAction<bool> StopEnemyPoolAction;//? 是否停止遊戲進度流程(敵人生成的進度流程)
    public static void StopEnemyPoolTrigger(bool b)
    {
        StopEnemyPoolAction?.Invoke(b);
    }
    public static UnityAction PlayerMissClearBulletAction;//? 玩家MISS後清除場上彈幕事件(所有敵方彈幕訂閱)
    public static void PlayerMissClearBulletTrigger()
    {
        PlayerMissClearBulletAction?.Invoke();
    }
    public static UnityAction BossDeathClearBulletAction;//? 清除BOSS一條血清除彈幕清除場上彈幕事件(所有敵方彈幕訂閱)
    public static void BossDeathClearBulletTrigger()
    {
        BossDeathClearBulletAction?.Invoke();
    }
    public static UnityAction<Transform> PlayerTouchAutoGetPropAction;//? 玩家觸碰到道具收取線事件(所有道具訂閱)   
    public static void PlayerTouchAutoGetPropTrigger(Transform t)
    {
        PlayerTouchAutoGetPropAction?.Invoke(t);
    }
    public static UnityAction<bool> ForPlayerDontControlAction;//? 使玩家不能控制事件
    public static void ForPlayerDontControlTrigger(bool f)
    {
        ForPlayerDontControlAction?.Invoke(f);
    }
    public static UnityAction<AudioClip> ChangeMusicAction;//? 改變音樂事件  
    public static void ChangeMusicTrigger(AudioClip c)
    {
        ChangeMusicAction?.Invoke(c);
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


}
