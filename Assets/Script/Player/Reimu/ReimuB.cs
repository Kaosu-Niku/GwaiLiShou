using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuB : Player
{
    [SerializeField] Transform ShootPos1;
    [SerializeField] Transform ShootPos2;
    [SerializeField] Transform ShootPos3;
    [SerializeField] Transform ShootPos4;
    protected override void CustomUseBomb()
    {
        GetPool.OutBullet("Bomb", transform.position, Quaternion.Euler(0, 0, 0));
        GetPool.OutBullet("Bomb1", transform.position, Quaternion.Euler(0, 0, 45));
        GetPool.OutBullet("Bomb2", transform.position, Quaternion.Euler(0, 0, 315));
        GetPool.OutBullet("Bomb3", transform.position, Quaternion.Euler(0, 0, 270));
        GetPool.OutBullet("Bomb4", transform.position, Quaternion.Euler(0, 0, 225));
        GetPool.OutBullet("Bomb5", transform.position, Quaternion.Euler(0, 0, 180));
        GetPool.OutBullet("Bomb6", transform.position, Quaternion.Euler(0, 0, 135));
        GetPool.OutBullet("Bomb7", transform.position, Quaternion.Euler(0, 0, 90));
    }
    protected override void CustomUseShoot()
    {
        StartCoroutine(ShootIEnum());
    }
    IEnumerator ShootIEnum()
    {
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
            {
                for (int x = 0; x < 3; x++)
                    GetPool.OutBullet("B0", new Vector3(transform.position.x - 0.1f, transform.position.y, 0), Quaternion.Euler(0, 0, 90));
                GetPool.OutBullet("B0", transform.position, Quaternion.Euler(0, 0, 90));
                for (int x = 0; x < 3; x++)
                    GetPool.OutBullet("B0", new Vector3(transform.position.x - 0.1f, transform.position.y, 0), Quaternion.Euler(0, 0, 90));
            }
            else//? 一般射擊
            {
                for (int x = 0; x < 2; x++)
                    GetPool.OutBullet("B0", ShootPos1.position, Quaternion.Euler(0, 0, 90));
                for (int x = 0; x < 2; x++)
                    GetPool.OutBullet("B0", ShootPos2.position, Quaternion.Euler(0, 0, 90));
                for (int x = 0; x < 2; x++)
                    GetPool.OutBullet("B0", ShootPos3.position, Quaternion.Euler(0, 0, 90));
                for (int x = 0; x < 2; x++)
                    GetPool.OutBullet("B0", ShootPos4.position, Quaternion.Euler(0, 0, 90));
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
}
