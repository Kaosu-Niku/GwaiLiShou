using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeA : Player
{
    BulletSystem Bomb;
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
                GetPool.OutBullet("A1", transform.position, Quaternion.identity);
            }
            else//? 一般射擊
            {
                GetPool.OutBullet("A0", transform.position, Quaternion.identity);
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
