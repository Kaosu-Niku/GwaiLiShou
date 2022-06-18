using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuA : Player
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
        Bullet[2].transform.position = transform.position;
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            ShootTime += Time.deltaTime;
            if (ShootTime > 0.1f)
            {
                if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
                {
                    for (int x = 0; x < 3; x++)
                        Instantiate(Bullet[1], new Vector3(transform.position.x - 0.15f + x * 0.15f, transform.position.y, 0), Quaternion.identity);
                    Bullet[2].SetActive(true);
                }
                else//? 一般射擊
                {
                    for (int x = 0; x < 7; x++)
                        Instantiate(Bullet[1], new Vector3(transform.position.x - 0.45f + x * 0.15f, transform.position.y, 0), Quaternion.identity);
                    Bullet[2].SetActive(false);
                }
                ShootTime = 0;
            }
            yield return 0;
        }
        ShootTime = 0;
        Bullet[2].SetActive(false);
        yield break;
    }
    new void Start()
    {
        base.Start();
        Bullet[2].SetActive(false);
    }
}
