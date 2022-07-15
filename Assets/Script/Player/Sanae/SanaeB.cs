using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SanaeB : Player
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
        while (MyInput.Player.Slow.ReadValue<float>() == 0 && MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            //? 一般射擊
            for (int x = 0; x < 4; x++)
                GetPool.OutBullet("B0", transform.position, Quaternion.Euler(0, 0, 60 + x * 20));
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void UseStoreShoot(InputAction.CallbackContext context)
    {
        StartCoroutine(StoreShoot());
    }
    IEnumerator StoreShoot()
    {

        float storeTime = 0;
        while (MyInput.Player.Slow.ReadValue<float>() == 1 && MyInput.Player.Shoot.ReadValue<float>() == 1)//? 集中射擊蓄力中
        {
            storeTime += Time.deltaTime;
            if (storeTime > 1)
            {
                GetPool.OutBullet("B4", transform.position, Quaternion.identity);
                storeTime = 0;
            }
            yield return 0;
        }
        if (storeTime < 0.2f) { }//? 集中射擊各階段
        else if (storeTime < 0.4f)
            GetPool.OutBullet("B1", transform.position, Quaternion.Euler(0, 0, 30));
        else if (storeTime < 0.6f)
            GetPool.OutBullet("B2", transform.position, Quaternion.Euler(0, 0, 30));
        else if (storeTime < 0.8f)
            GetPool.OutBullet("B3", transform.position, Quaternion.Euler(0, 0, 30));
        else
            GetPool.OutBullet("B4", transform.position, Quaternion.Euler(0, 0, 30));
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
        MyInput.Player.Slow.performed += UseStoreShoot;
    }
    private void OnDestroy()
    {
        MyInput.Player.Slow.performed -= UseStoreShoot;
    }
}
