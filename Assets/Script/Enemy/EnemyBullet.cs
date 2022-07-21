using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBullet : BulletSystem
{
    protected abstract IEnumerator Doing();
    protected override IEnumerator FirstDoing()
    {
        yield return StartCoroutine(Doing());
    }
    [SerializeField] protected float Speed; //* 子彈移動速度
    [SerializeField] bool NotClear;//* 該子彈是否不能被正常清除
    bool IsGraze = false;//* 是否擦彈
    new void OnEnable()
    {
        base.OnEnable();
        GameRunSO.PlayerMissClearBulletAction += NowClearBullet;
        GameRunSO.BossDeathClearBulletAction += NowMustClearBullet;
    }
    new void OnDisable()
    {
        base.OnDisable();
        GameRunSO.PlayerMissClearBulletAction -= NowClearBullet;
        GameRunSO.BossDeathClearBulletAction -= NowMustClearBullet;
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //? 離開戰鬥區域
        if (other.gameObject.CompareTag("Wall"))
            NowClearBullet();
        //? 玩家接觸就判定玩家中彈
        if (other.gameObject.CompareTag("Player"))
        {
            GameRunSO.PlayerMissTrigger();
            NowClearBullet();
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

    private void NowClearBullet()
    {
        if (NotClear == false)
            gameObject.SetActive(false);
    }
    public void CallNowClearBullet()
    {
        NowClearBullet();
    }
    private void NowMustClearBullet()
    {
        gameObject.SetActive(false);
    }
    public void CallNowMustClearBullet()
    {
        NowMustClearBullet();
    }
}
