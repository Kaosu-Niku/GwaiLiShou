using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeB : Player
{
    BulletSystem Bomb;
    BulletSystem B1;
    BulletSystem B2;
    BulletSystem B3;
    BulletSystem B4;
    float StoreTime; //* 慢速射擊充能時間
    protected override void CustomUseBomb()
    {
        Bomb.gameObject.SetActive(true);
    }
    protected override void CustomUseShoot()
    {
        StartCoroutine(ShootIEnum());
    }
    IEnumerator ShootIEnum()
    {
        StartCoroutine(StoreShoot());
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            //? 一般射擊
            GetPool.OutBullet("B0", transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
    IEnumerator StoreShoot()
    {
        if (MyInput.Player.Slow.ReadValue<float>() == 0)
        {

        }
        if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊蓄力中
        {
            StoreTime += Time.deltaTime;
            if (StoreTime > 1)
            {
                B4.gameObject.SetActive(true);
                StoreTime = 0;
            }
            yield return 0;
        }
        else
        {
            if (StoreTime < 0.2f) { }//? 集中射擊各階段
            else if (StoreTime < 0.4f)
                B1.gameObject.SetActive(true);
            else if (StoreTime < 0.6f)
                B2.gameObject.SetActive(true);
            else if (StoreTime < 0.8f)
                B3.gameObject.SetActive(true);
            else
                B4.gameObject.SetActive(true);
            StoreTime = 0;
        }
        yield return 0;
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
        B1 = GetPool.OutBullet("B1", transform.position, Quaternion.identity);
        B1.gameObject.SetActive(false);
        B2 = GetPool.OutBullet("B2", transform.position, Quaternion.identity);
        B2.gameObject.SetActive(false);
        B3 = GetPool.OutBullet("B3", transform.position, Quaternion.identity);
        B3.gameObject.SetActive(false);
        B4 = GetPool.OutBullet("B4", transform.position, Quaternion.identity);
        B4.gameObject.SetActive(false);
    }
}
