using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 測試用BOSS : Boss
{
    bool Dir2;
    protected override void BossResetAction()
    {
        switch (Stage)
        {
            case 0:
                AddBossStartAction(Action00());
                break;
            case 1:
                AddBossStartAction(Action01());
                break;
            case 2:
                AddBossStartAction(Action02());
                break;
            case 3:
                AddBossStartAction(Action03());
                AddBossStartAction(Action03_1());
                break;
            case 4:
                AddBossStartAction(Action04());
                break;
        }
    }
    IEnumerator Action00()
    {
        while (true)
        {
            if (Dir2 == false)
                for (int x = 0; x < 72; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, x * 5));
            else
                for (int x = 0; x < 72; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, 2.5f + x * 5));
            Dir2 = !Dir2;
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator Action01()
    {
        while (true)
        {
            if (Dir2 == false)
                for (int x = 0; x < 72; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, x * 5));
            else
                for (int x = 0; x < 72; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, 2.5f + x * 5));
            Dir2 = !Dir2;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Action02()
    {
        while (true)
        {
            if (Dir2 == false)
                for (int x = 0; x < 45; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, x * 8));
            else
                for (int x = 0; x < 45; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, 4 + x * 8));
            Dir2 = !Dir2;
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator Action03()
    {
        int num = 0;
        while (true)
        {
            if (Dir2 == false)
                for (int x = 0; x < 72; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, x * 5));
            else
                for (int x = 0; x < 72; x++)
                    Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, 2.5f + x * 5));
            Dir2 = !Dir2;
            num++;
            yield return new WaitForSeconds(0.2f);
            if (num > 5)
            {
                num = 0;
                yield return new WaitForSeconds(2.8f);
            }
            yield return 0;
        }
    }
    IEnumerator Action03_1()
    {
        while (true)
        {
            yield return 0;
        }
    }
    IEnumerator Action04()
    {
        while (true)
        {
            yield return 0;
        }
    }
}
