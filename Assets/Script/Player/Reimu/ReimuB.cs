using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuB : Player
{
    protected override void CustomUseBomb()
    {
        GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
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
                    GetPool.OutBullet("B0", new Vector3(transform.position.x - 0.1f, transform.position.y, 0), Quaternion.identity);
                GetPool.OutBullet("B0", transform.position, Quaternion.identity);
                for (int x = 0; x < 3; x++)
                    GetPool.OutBullet("B0", new Vector3(transform.position.x - 0.1f, transform.position.y, 0), Quaternion.identity);
            }
            else//? 一般射擊
            {
                for (int x = 0; x < 7; x++)
                    GetPool.OutBullet("B0", new Vector3(transform.position.x - 0.6f + x * 0.2f, transform.position.y, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
}
