using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float BulletMagn; //* 子彈傷害倍率
    [SerializeField] protected float Speed; //* 子彈移動速度
    protected float BulletAttack; //* 子彈總攻擊力
    [SerializeField] bool DontDestroy; //* 子彈是否要被正常刪除(若非正常需在子腳本自訂刪除)
    [SerializeField] float DestroyTime; //* 刪除時間

    protected void Awake()
    {
        //? 子彈總攻擊力
        BulletAttack = (GameDataSO.PlayerPower + GameDataSO.PlayerSkillPower) * BulletMagn;
        if (DontDestroy == false)
            Destroy(this.gameObject, DestroyTime);
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        //? 離開戰鬥區域
        if (other.gameObject.CompareTag("Wall"))
            if (DontDestroy == false)
                Destroy(this.gameObject);
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
                if (DontDestroy == false)
                    Destroy(this.gameObject);
            }
        }
    }
}
