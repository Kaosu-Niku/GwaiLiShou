using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuA : Player
{
    BulletSystem A1;
    protected override void CustomUseBomb()
    {
        for (int x = 0; x < 8; x++)
        {
            GetPool.OutBullet("Bomb", transform.position, Quaternion.Euler(0, 0, x * 45));
        }
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
                    GetPool.OutBullet("A0", new Vector3(transform.position.x - 0.15f + x * 0.15f, transform.position.y, 0), Quaternion.Euler(0, 0, 90));
                if (A1.gameObject.activeInHierarchy == false)
                    A1.transform.position = transform.position;
                A1.gameObject.SetActive(true);
            }
            else//? 一般射擊
            {
                for (int x = 0; x < 7; x++)
                    GetPool.OutBullet("A0", new Vector3(transform.position.x - 0.45f + x * 0.15f, transform.position.y, 0), Quaternion.Euler(0, 0, 90));
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
