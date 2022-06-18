using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeA : Player
{
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
            if (ShootTime > 0.1f)
            {
                if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
                {
                    Instantiate(Bullet[2], transform.position, Quaternion.identity);
                }
                else//? 一般射擊
                {
                    Instantiate(Bullet[1], transform.position, Quaternion.identity);
                }
                ShootTime = 0;
            }
            yield return 0;
        }
        ShootTime = 0;
        yield break;
    }
}
