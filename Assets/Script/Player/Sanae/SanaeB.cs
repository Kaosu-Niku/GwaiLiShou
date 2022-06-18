using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeB : Player
{
    float StoreTime; //* 慢速射擊充能時間
    protected override void CustomUseBomb()
    {
        Instantiate(Bullet[0], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
    protected override void CustomUseShoot()
    {
        StartCoroutine(ShootIEnum());
    }
    IEnumerator ShootIEnum()
    {
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            ShootTime += Time.deltaTime;
            if (ShootTime > 0.1f)//? 一般射擊
            {
                Instantiate(Bullet[1], transform.position, Quaternion.identity);
                ShootTime = 0;
            }
            if (MyInput.Player.Slow.ReadValue<float>() == 0)
            {
                if (StoreTime < 0.2f) { }//? 集中射擊各階段
                else if (StoreTime < 0.4f)
                    Instantiate(Bullet[2], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else if (StoreTime < 0.6f)
                    Instantiate(Bullet[3], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else if (StoreTime < 0.8f)
                    Instantiate(Bullet[4], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else
                    Instantiate(Bullet[5], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                StoreTime = 0;
            }
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊最大蓄力
            {
                StoreTime += Time.deltaTime;
                if (StoreTime > 1)
                {
                    Instantiate(Bullet[5], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    StoreTime = 0;
                }
            }
            yield return 0;
        }
        ShootTime = 0;
        StoreTime = 0;
        yield break;
    }
}
