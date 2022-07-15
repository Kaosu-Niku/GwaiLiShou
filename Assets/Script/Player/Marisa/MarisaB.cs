using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaB : Player
{
    BulletSystem Bomb;
    BulletSystem B1;
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
                B1.gameObject.SetActive(true);
            }
            else//? 一般射擊
            {
                B1.gameObject.SetActive(false);
                for (int x = 0; x < 5; x++)
                    GetPool.OutBullet("B0", new Vector3(transform.position.x - 0.4f + x * 0.2f, transform.position.y, 0), Quaternion.Euler(0, 0, 90));
            }
            yield return new WaitForSeconds(0.1f);
        }
        B1.gameObject.SetActive(false);
        yield break;
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
        B1 = GetPool.OutBullet("B1", transform.position, Quaternion.identity);
        B1.gameObject.SetActive(false);
    }
}
