using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuA : Player
{
    BulletSystem A1;
    protected override void CustomUseBomb()
    {
        GetPool.OutBullet("Bomb", transform.position, Quaternion.Euler(0, 0, 0));
        GetPool.OutBullet("Bomb1", transform.position, Quaternion.Euler(0, 0, 45));
        GetPool.OutBullet("Bomb2", transform.position, Quaternion.Euler(0, 0, 315));
        GetPool.OutBullet("Bomb3", transform.position, Quaternion.Euler(0, 0, 270));
        GetPool.OutBullet("Bomb4", transform.position, Quaternion.Euler(0, 0, 225));
        GetPool.OutBullet("Bomb5", transform.position, Quaternion.Euler(0, 0, 180));
        GetPool.OutBullet("Bomb6", transform.position, Quaternion.Euler(0, 0, 135));
        GetPool.OutBullet("Bomb7", transform.position, Quaternion.Euler(0, 0, 90));
    }
    protected override void CustomUseShoot()
    {
        StartCoroutine(ShootIEnum());
    }
    IEnumerator ShootIEnum()
    {
        StartCoroutine(MainShoot());
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
            {
                if (A1.gameObject.activeInHierarchy == false)
                {
                    A1.transform.position = transform.position;
                    A1.gameObject.SetActive(true);
                }
            }
            else//? 一般射擊
            {

                if (GameDataSO.PlayerPower == 4)
                {
                    GetPool.OutBullet("A0", new Vector3(transform.position.x - 0.8f, transform.position.y - 0.15f, 0), Quaternion.Euler(0, 0, 120));
                    GetPool.OutBullet("A0", new Vector3(transform.position.x - 0.4f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 105));
                    GetPool.OutBullet("A0", new Vector3(transform.position.x + 0.4f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 75));
                    GetPool.OutBullet("A0", new Vector3(transform.position.x + 0.8f, transform.position.y - 0.15f, 0), Quaternion.Euler(0, 0, 60));
                }
                else if (GameDataSO.PlayerPower >= 3)
                {
                    GetPool.OutBullet("A0", new Vector3(transform.position.x - 0.8f, transform.position.y - 0.15f, 0), Quaternion.Euler(0, 0, 120));
                    GetPool.OutBullet("A0", new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 105));
                    GetPool.OutBullet("A0", new Vector3(transform.position.x + 0.8f, transform.position.y - 0.15f, 0), Quaternion.Euler(0, 0, 60));
                }
                else if (GameDataSO.PlayerPower >= 2)
                {
                    GetPool.OutBullet("A0", new Vector3(transform.position.x - 0.8f, transform.position.y - 0.15f, 0), Quaternion.Euler(0, 0, 120));
                    GetPool.OutBullet("A0", new Vector3(transform.position.x + 0.8f, transform.position.y - 0.15f, 0), Quaternion.Euler(0, 0, 60));
                }
                else
                {
                    GetPool.OutBullet("A0", new Vector3(transform.position.x, transform.position.y + 0.5f, 0), Quaternion.Euler(0, 0, 105));
                }
                if (A1.gameObject.activeInHierarchy == true)
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
    IEnumerator MainShoot()
    {
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            GetPool.OutBullet("Main", new Vector3(transform.position.x - 0.15f, transform.position.y + 0.25f, 0), Quaternion.Euler(0, 0, 90));
            GetPool.OutBullet("Main", new Vector3(transform.position.x + 0.15f, transform.position.y + 0.25f, 0), Quaternion.Euler(0, 0, 90));
            yield return new WaitForSeconds(0.05f);
        }
        yield break;
    }
}
