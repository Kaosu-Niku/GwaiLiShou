using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaA : Player
{
    protected override void CustomUseBomb()
    {
        Instantiate(Bullet[7], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
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
                    for (int x = 0; x < 5; x++)
                        Bullet[x].SetActive(false);
                    for (int x = 5; x < 7; x++)
                        Bullet[x].SetActive(true);
                }
                else//? 一般射擊
                {
                    for (int x = 0; x < 5; x++)
                        Bullet[x].SetActive(true);
                    for (int x = 5; x < 7; x++)
                        Bullet[x].SetActive(false);
                }
                ShootTime = 0;
            }
            yield return 0;
        }
        ShootTime = 0;
        for (int x = 0; x < 7; x++)
            Bullet[x].SetActive(false);
        yield break;
    }
    new void Start()
    {
        base.Start();
        for (int x = 0; x < 7; x++)
            Bullet[x].SetActive(false);
    }
}

