using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SanaeB : Player
{
    BulletSystem Bomb;
    [SerializeField] Transform ShootPos1;
    [SerializeField] Transform ShootPos2;
    [SerializeField] Transform ShootPos3;
    [SerializeField] Transform ShootPos4;
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
            for (int x = 0; x < 3; x++)
                GetPool.OutBullet("B0", ShootPos1.position, Quaternion.Euler(0, 0, 60 + x * 30));
            for (int x = 0; x < 4; x++)
                GetPool.OutBullet("B0", ShootPos2.position, Quaternion.Euler(0, 0, 75 + x * 10));
            for (int x = 0; x < 3; x++)
                GetPool.OutBullet("B0", ShootPos3.position, Quaternion.Euler(0, 0, 45 + x * 45));
            for (int x = 0; x < 3; x++)
                GetPool.OutBullet("B0", ShootPos4.position, Quaternion.Euler(0, 0, 45 + x * 45));
            yield return new WaitForSeconds(0.2f);
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
            yield return 0;
        }
        if (storeTime < 0.5f) { }//? 集中射擊各階段
        else if (storeTime < 1)
            GetPool.OutBullet("B1", transform.position, Quaternion.Euler(0, 0, 55));
        else if (storeTime < 1.5f)
            GetPool.OutBullet("B2", transform.position, Quaternion.Euler(0, 0, 55));
        else if (storeTime < 2)
            GetPool.OutBullet("B3", transform.position, Quaternion.Euler(0, 0, 55));
        else
            GetPool.OutBullet("B4", transform.position, Quaternion.Euler(0, 0, 55));

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
