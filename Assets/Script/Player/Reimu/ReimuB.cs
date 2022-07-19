using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuB : Player
{
    [SerializeField] Transform[] ShootPos = new Transform[8];
    Coroutine C;
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
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
            {
                if (C != null)
                    StopCoroutine(C);
                C = StartCoroutine(ClosePos());
                for (int x = 0; x < 8; x++)
                    GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 90));
                yield return new WaitForSeconds(0.075f);
            }
            else//? 一般射擊
            {
                if (C != null)
                    StopCoroutine(C);
                C = StartCoroutine(OpenPos());
                for (int x = 0; x < 8; x += 2)
                    GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 92.5f));
                for (int x = 1; x < 8; x += 2)
                    GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 87.5f));
                yield return new WaitForSeconds(0.1f);
            }

        }
        yield break;
    }
    IEnumerator OpenPos()
    {
        Vector3[] pos = new Vector3[8] { new Vector3(-0.8f, 0.25f, 0), new Vector3(-0.7f, 0.25f, 0), new Vector3(-0.3f, 0.5f, 0), new Vector3(-0.2f, 0.5f, 0),
        new Vector3(0.2f, 0.5f, 0), new Vector3(0.3f, 0.5f, 0), new Vector3(0.7f, 0.25f, 0), new Vector3(0.8f, 0.25f, 0)};
        for (float x = 0; x < 1; x += Time.deltaTime)
        {
            for (int y = 0; y < 8; y++)
            {
                ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, pos[y], Time.deltaTime * 10);
            }
            yield return 0;
        }
    }
    IEnumerator ClosePos()
    {
        Vector3[] pos = new Vector3[8] { new Vector3(-0.35f, 0.25f, 0), new Vector3(-0.25f, 0.25f, 0), new Vector3(-0.15f, 0.5f, 0), new Vector3(-0.05f, 0.5f, 0) ,
        new Vector3(0.05f, 0.5f, 0), new Vector3(0.15f, 0.5f, 0),new Vector3(0.25f, 0.25f, 0), new Vector3(0.35f, 0.25f, 0)};
        for (float x = 0; x < 1; x += Time.deltaTime)
        {
            for (int y = 0; y < 8; y++)
            {
                ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, pos[y], Time.deltaTime * 10);
            }
            yield return 0;
        }
    }
}
