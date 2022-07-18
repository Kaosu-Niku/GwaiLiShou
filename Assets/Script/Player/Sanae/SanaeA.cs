using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeA : Player
{
    BulletSystem Bomb;
    [SerializeField] Transform ShootPos1;
    [SerializeField] Transform ShootPos2;
    [SerializeField] Transform ShootPos3;
    [SerializeField] Transform ShootPos4;
    [SerializeField] Transform SlowShootPos1;
    [SerializeField] Transform SlowShootPos2;
    [SerializeField] Transform SlowShootPos3;
    [SerializeField] Transform SlowShootPos4;
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
        bool b = false;
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
            {
                GetPool.OutBullet("A1", SlowShootPos1.position, Quaternion.identity);
                GetPool.OutBullet("A1", SlowShootPos2.position, Quaternion.identity);
                GetPool.OutBullet("A1", SlowShootPos3.position, Quaternion.identity);
                GetPool.OutBullet("A1", SlowShootPos4.position, Quaternion.identity);
                yield return new WaitForSeconds(0.15f);
            }
            else//? 一般射擊
            {
                if (b == false)
                {
                    GetPool.OutBullet("A0", ShootPos1.position, Quaternion.Euler(0, 0, 105));
                    GetPool.OutBullet("A0", ShootPos2.position, Quaternion.Euler(0, 0, 90));
                    GetPool.OutBullet("A0", ShootPos3.position, Quaternion.Euler(0, 0, 75));
                    GetPool.OutBullet("A0", ShootPos4.position, Quaternion.Euler(0, 0, 90));
                }
                else
                {
                    GetPool.OutBullet("A0", ShootPos1.position, Quaternion.Euler(0, 0, 75));
                    GetPool.OutBullet("A0", ShootPos2.position, Quaternion.Euler(0, 0, 120));
                    GetPool.OutBullet("A0", ShootPos3.position, Quaternion.Euler(0, 0, 105));
                    GetPool.OutBullet("A0", ShootPos4.position, Quaternion.Euler(0, 0, 60));
                }
                b = !b;
                yield return new WaitForSeconds(0.5f);
            }

        }
        yield break;
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
    }
}
