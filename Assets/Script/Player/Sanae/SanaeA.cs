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
                GetPool.OutBullet("A1", new Vector3(transform.position.x - 0.5f, transform.position.y + 0.25f, 0), Quaternion.identity);
                GetPool.OutBullet("A1", new Vector3(transform.position.x - 0.25f, transform.position.y + 0.5f, 0), Quaternion.identity);
                GetPool.OutBullet("A1", new Vector3(transform.position.x, transform.position.y + 0.75f, 0), Quaternion.identity);
                GetPool.OutBullet("A1", new Vector3(transform.position.x + 0.25f, transform.position.y + 0.5f, 0), Quaternion.identity);
                GetPool.OutBullet("A1", new Vector3(transform.position.x + 0.5f, transform.position.y + 0.25f, 0), Quaternion.identity);
            }
            else//? 一般射擊
            {
                for (int x = 0; x < 5; x++)
                    GetPool.OutBullet("A0", transform.position, Quaternion.Euler(0, 0, 50 + x * 20));
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
