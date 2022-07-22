using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuB : Player
{
    [SerializeField] Transform[] ShootPos = new Transform[8];
    Vector3[] OpenPos1 = new Vector3[2] { new Vector3(-0.05f, 0.55f, 0), new Vector3(0.05f, 0.55f, 0) };
    Vector3[] ClosePos1 = new Vector3[2] { new Vector3(-0.05f, 0.25f, 0), new Vector3(0.05f, 0.25f, 0) };
    Vector3[] OpenPos2 = new Vector3[4] { new Vector3(-0.8f, 0, 0), new Vector3(-0.7f, 0, 0), new Vector3(0.7f, 0, 0), new Vector3(0.8f, 0, 0) };
    Vector3[] ClosePos2 = new Vector3[4] { new Vector3(-0.35f, 0.25f, 0), new Vector3(-0.25f, 0.25f, 0), new Vector3(0.25f, 0.25f, 0), new Vector3(0.35f, 0.25f, 0) };
    Vector3[] OpenPos3 = new Vector3[6] { new Vector3(-0.8f, 0, 0), new Vector3(-0.7f, 0, 0), new Vector3(0.7f, 0, 0), new Vector3(0.8f, 0, 0) ,
        new Vector3(-0.05f, 0.55f, 0), new Vector3(0.05f, 0.55f, 0)};
    Vector3[] ClosePos3 = new Vector3[6] { new Vector3(-0.35f, 0.25f, 0), new Vector3(-0.25f, 0.25f, 0), new Vector3(0.25f, 0.25f, 0), new Vector3(0.35f, 0.25f, 0) ,
        new Vector3(-0.05f, 0.25f, 0), new Vector3(0.05f, 0.25f, 0)};
    Vector3[] OpenPos4 = new Vector3[8] { new Vector3(-0.8f, 0, 0), new Vector3(-0.7f, 0, 0), new Vector3(-0.3f, 0.5f, 0), new Vector3(-0.2f, 0.5f, 0),
        new Vector3(0.2f, 0.5f, 0), new Vector3(0.3f, 0.5f, 0), new Vector3(0.7f, 0, 0), new Vector3(0.8f, 0, 0)};
    Vector3[] ClosePos4 = new Vector3[8] { new Vector3(-0.35f, 0.25f, 0), new Vector3(-0.25f, 0.25f, 0), new Vector3(-0.15f, 0.25f, 0), new Vector3(-0.05f, 0.25f, 0) ,
        new Vector3(0.05f, 0.25f, 0), new Vector3(0.15f, 0.25f, 0),new Vector3(0.25f, 0.25f, 0), new Vector3(0.35f, 0.25f, 0)};
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
        StartCoroutine(MainShoot());
        while (MyInput.Player.Shoot.ReadValue<float>() == 1)
        {
            if (MyInput.Player.Slow.ReadValue<float>() == 1)//? 集中射擊
            {
                if (C != null)
                    StopCoroutine(C);
                C = StartCoroutine(ClosePos());
                if (GameDataSO.PlayerPower == 4)
                {
                    for (int x = 0; x < 8; x++)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 90));
                }
                else if (GameDataSO.PlayerPower >= 3)
                {
                    for (int x = 0; x < 6; x++)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 90));
                }
                else if (GameDataSO.PlayerPower >= 2)
                {
                    for (int x = 0; x < 4; x++)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 90));
                }
                else
                {
                    for (int x = 0; x < 2; x++)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 90));
                }

                yield return new WaitForSeconds(0.075f);
            }
            else//? 一般射擊
            {
                if (C != null)
                    StopCoroutine(C);
                C = StartCoroutine(OpenPos());
                if (GameDataSO.PlayerPower == 4)
                {
                    for (int x = 0; x < 8; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 92.5f));
                    for (int x = 1; x < 8; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 87.5f));
                }
                else if (GameDataSO.PlayerPower >= 3)
                {
                    for (int x = 0; x < 6; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 92.5f));
                    for (int x = 1; x < 6; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 87.5f));
                }
                else if (GameDataSO.PlayerPower >= 2)
                {
                    for (int x = 0; x < 4; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 92.5f));
                    for (int x = 1; x < 4; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 87.5f));
                }
                else
                {
                    for (int x = 0; x < 2; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 92.5f));
                    for (int x = 1; x < 2; x += 2)
                        GetPool.OutBullet("B0", ShootPos[x].position, Quaternion.Euler(0, 0, 87.5f));
                }

                yield return new WaitForSeconds(0.1f);
            }

        }
        yield break;
    }
    IEnumerator OpenPos()
    {

        if (GameDataSO.PlayerPower == 4)
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 8; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, OpenPos4[y], Time.deltaTime * 10);
                yield return 0;
            }
        }
        else if (GameDataSO.PlayerPower >= 3)
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 6; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, OpenPos3[y], Time.deltaTime * 10);
                yield return 0;
            }
        }
        else if (GameDataSO.PlayerPower >= 2)
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 4; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, OpenPos2[y], Time.deltaTime * 10);
                yield return 0;
            }
        }
        else
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 2; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, OpenPos1[y], Time.deltaTime * 10);
                yield return 0;
            }
        }

    }
    IEnumerator ClosePos()
    {

        if (GameDataSO.PlayerPower == 4)
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 8; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, ClosePos4[y], Time.deltaTime * 10);
                yield return 0;
            }
        }
        else if (GameDataSO.PlayerPower >= 3)
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 6; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, ClosePos3[y], Time.deltaTime * 10);
                yield return 0;
            }
        }
        else if (GameDataSO.PlayerPower >= 2)
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 4; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, ClosePos2[y], Time.deltaTime * 10);
                yield return 0;
            }
        }
        else
        {
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                for (int y = 0; y < 2; y++)
                    ShootPos[y].localPosition = Vector3.Lerp(ShootPos[y].localPosition, ClosePos1[y], Time.deltaTime * 10);
                yield return 0;
            }
        }

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
