using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaA : Player
{
    BulletSystem Bomb;
    BulletSystem[] A0 = new BulletSystem[5];
    BulletSystem A1;
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
                for (int x = 0; x < 5; x++)
                    A0[x].gameObject.SetActive(false);
                A1.gameObject.SetActive(true);
            }
            else//? 一般射擊
            {
                for (int x = 0; x < 5; x++)
                    A0[x].gameObject.SetActive(true);
                A1.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
        }
        for (int x = 0; x < 5; x++)
            A0[x].gameObject.SetActive(false);
        A1.gameObject.SetActive(false);
        yield break;
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
        for (int x = 0; x < 5; x++)
        {
            A0[x] = GetPool.OutBullet("A0", transform.position, Quaternion.Euler(0, 0, 50 + x * 20));
            A0[x].gameObject.SetActive(false);
        }
        A1 = GetPool.OutBullet("A1", transform.position, Quaternion.identity);
        A1.gameObject.SetActive(false);
    }
}

