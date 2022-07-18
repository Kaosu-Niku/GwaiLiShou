using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaB : Player
{
    BulletSystem Bomb;
    [SerializeField] Transform ShootPos1;
    [SerializeField] Transform ShootPos2;
    [SerializeField] Transform ShootPos3;
    [SerializeField] Transform ShootPos4;
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
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
            {
                GetPool.OutBullet("B1", transform.position, Quaternion.Euler(0, 0, 90));
            }
            else//? 一般射擊
            {
                GetPool.OutBullet("B0", ShootPos1.position, Quaternion.Euler(0, 0, 90));
                GetPool.OutBullet("B0", ShootPos2.position, Quaternion.Euler(0, 0, 90));
                GetPool.OutBullet("B0", ShootPos3.position, Quaternion.Euler(0, 0, 90));
                GetPool.OutBullet("B0", ShootPos4.position, Quaternion.Euler(0, 0, 90));
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
    }
}
