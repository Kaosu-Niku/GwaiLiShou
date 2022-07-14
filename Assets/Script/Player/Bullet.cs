using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : BulletSystem
{
    protected abstract IEnumerator Doing();
    protected override IEnumerator FirstDoing()
    {
        yield return StartCoroutine(Doing());
    }
    [SerializeField] protected float BulletMagn; //* 子彈傷害倍率
    [SerializeField] protected float Speed; //* 子彈移動速度
    protected float BulletAttack; //* 子彈總攻擊力
    [SerializeField] bool NotClear;//* 該子彈是否不能被正常清除
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //? 離開戰鬥區域
        if (other.gameObject.CompareTag("Wall"))
            if (NotClear == false)
                gameObject.SetActive(false);
        //? 碰到敵人
        if (other.gameObject.CompareTag("Enemy"))
        {
            try
            {
                Enemy e = other.GetComponent<Enemy>();
                if (e)
                    e.Hurt(BulletAttack);
                Boss b = other.GetComponent<Boss>();
                if (b)
                    b.Hurt(BulletAttack);
            }
            finally
            {
                if (NotClear == false)
                    gameObject.SetActive(false);
            }
        }
    }
    protected void Start()
    {
        //? 子彈總攻擊力
        BulletAttack = (GameDataSO.PlayerPower + GameDataSO.PlayerSkillPower) * BulletMagn;
    }
}
