using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaA : Player
{
    BulletSystem Bomb;
    BulletSystem[] A0 = new BulletSystem[4];
    [SerializeField] Transform[] ShootPos = new Transform[4];
    Coroutine C;
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
                if (C != null)
                    StopCoroutine(C);
                C = StartCoroutine(ClosePos());
            }
            else//? 一般射擊
            {
                if (C != null)
                    StopCoroutine(C);
                C = StartCoroutine(OpenPos());
            }
            for (int x = 0; x < 4; x++)
                A0[x].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        for (int x = 0; x < 4; x++)
            A0[x].gameObject.SetActive(false);
        yield break;
    }
    IEnumerator OpenPos()
    {
        Vector3[] pos = new Vector3[4] { new Vector3(-0.9f, 0.5f, 0), new Vector3(-0.3f, 0.5f, 0), new Vector3(0.3f, 0.5f, 0), new Vector3(0.9f, 0.5f, 0) };
        for (float x = 0; x < 1; x += Time.deltaTime)
        {
            for (int y = 0; y < 4; y++)
            {
                ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, pos[y], Time.deltaTime * 10);
            }
            yield return 0;
        }
    }
    IEnumerator ClosePos()
    {
        Vector3[] pos = new Vector3[4] { new Vector3(-0.375f, 0.5f, 0), new Vector3(-0.125f, 0.5f, 0), new Vector3(0.125f, 0.5f, 0), new Vector3(0.375f, 0.5f, 0) };
        for (float x = 0; x < 1; x += Time.deltaTime)
        {
            for (int y = 0; y < 4; y++)
            {
                ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, pos[y], Time.deltaTime * 10);
            }
            yield return 0;
        }
    }
    private void Start()
    {
        Bomb = GetPool.OutBullet("Bomb", transform.position, Quaternion.identity);
        Bomb.gameObject.SetActive(false);
        for (int x = 0; x < 4; x++)
        {
            A0[x] = GetPool.OutBullet("A0", ShootPos[x].position, Quaternion.Euler(0, 0, 90));
            A0[x].transform.parent = ShootPos[x];
            A0[x].gameObject.SetActive(false);
        }
    }
}

