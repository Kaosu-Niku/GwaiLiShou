using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuA : Player
{
    BulletSystem A1;
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
                if (A1.gameObject.activeInHierarchy == false)
                    A1.transform.position = transform.position;
                A1.gameObject.SetActive(true);
            }
            else//? 一般射擊
            {

                GetPool.OutBullet("A0", ShootPos1.position, Quaternion.Euler(0, 0, 120));
                GetPool.OutBullet("A0", ShootPos2.position, Quaternion.Euler(0, 0, 105));
                GetPool.OutBullet("A0", ShootPos3.position, Quaternion.Euler(0, 0, 75));
                GetPool.OutBullet("A0", ShootPos4.position, Quaternion.Euler(0, 0, 60));
                A1.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
        }
        A1.gameObject.SetActive(false);
        yield break;
    }
    private void Start()
    {
        A1 = GetPool.OutBullet("A1", transform.position, Quaternion.identity);
        A1.gameObject.SetActive(false);
    }
}
