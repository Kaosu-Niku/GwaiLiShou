using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] protected float Speed; //* 子彈移動速度
    [SerializeField] bool DontDestroy; //* 子彈是否要被正常刪除(若非正常需在子腳本自訂刪除)
    [SerializeField] float DestroyTime; //* 刪除時間
    bool IsGraze = false;//* 是否擦彈
    protected void Awake()
    {
        if (DontDestroy == false)
            Destroy(this.gameObject, DestroyTime);
    }
    private void OnEnable()
    {
        GameRunSO.PlayerMissClearBulletAction += NowDestroyBullet;
        GameRunSO.BossDeathClearBulletAction += NowMustDeatroyBullet;
    }
    private void OnDisable()
    {
        GameRunSO.PlayerMissClearBulletAction -= NowDestroyBullet;
        GameRunSO.BossDeathClearBulletAction -= NowMustDeatroyBullet;
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //? 離開戰鬥區域
        if (other.gameObject.CompareTag("Wall"))
            NowDestroyBullet();
        //? 玩家接觸就判定玩家中彈
        if (other.gameObject.CompareTag("Player"))
        {
            GameRunSO.PlayerMissTrigger();
            NowDestroyBullet();
            Debug.Log("你中彈了(訊息來自EnemyBullet)");
        }
        //? 擦彈判定
        if (other.gameObject.CompareTag("Graze"))
        {
            if (IsGraze == false)
            {
                IsGraze = true;
                GameDataSO.Score += 50000;
                GameDataSO.Graze++;
            }
        }
    }
    public void NowDestroyBullet()
    {
        if (DontDestroy == false)
            Destroy(this.gameObject);
    }
    public void NowMustDeatroyBullet()
    {
        Destroy(this.gameObject);
    }
}
