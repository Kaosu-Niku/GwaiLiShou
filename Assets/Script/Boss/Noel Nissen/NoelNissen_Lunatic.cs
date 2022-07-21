using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen_Lunatic : Boss
{
    bool Ready;
    bool Dir = false;
    Vector3 Target;
    bool Speed0;
    int num0;
    GameObject Obj2;
    int Num2;
    bool Change4;
    int NowRandom5;
    protected override void BossResetAction()
    {
        switch (Stage)
        {
            case 0:
                AddBossStartAction(Action00());
                AddBossStartAction(Action00_1());
                break;
            case 1:
                AddBossStartAction(Action01());
                AddBossStartAction(Action01_1());
                AddBossStartAction(Action01_2());
                Reset = new Vector3(0, 2, 0);
                break;
            case 2:
                AddBossStartAction(Action02());
                AddBossStartAction(Action02_1());
                Reset = new Vector3(0, 3, 0);
                transform.rotation = Quaternion.identity;
                Obj2 = Instantiate(Bullet[4]);
                break;
            case 3:
                AddBossStartAction(Action03());
                AddBossStartAction(Action03_1());
                AddBossStartAction(Action03_2());
                Destroy(Obj2);
                GetPlayer.ResetPoint = new Vector3(0, 2, 0);
                break;
            case 4:
                AddBossStartAction(Action04());
                AddBossStartAction(Action04_1());
                break;
            case 5:
                AddBossStartAction(Action05());
                AddBossStartAction(Action05_1());
                GetPlayer.ResetPoint = new Vector3(0, -3.5f, 0);
                break;
        }
    }

    IEnumerator Action00()
    {
        while (true)
        {
            while (Ready == true)
            {
                if (Speed0 == false)
                {
                    for (int y = 0; y < 37; y++)
                        Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 0, y * 5));
                }
                else
                {
                    for (int y = 0; y < 37; y++)
                        Instantiate(Bullet[1], transform.position, Quaternion.Euler(0, 0, y * 5));
                }
                num0++;
                if (num0 > 9)
                {
                    num0 = 0;
                    Ready = false;
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return 0;
        }
    }
    IEnumerator Action00_1()
    {
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-5, 2, 0);
            else
                Target = new Vector3(5, 2, 0);
            while (transform.position != Target)
            {
                if (Speed0 == false)
                    transform.position = Vector3.MoveTowards(transform.position, Target, 2.5f * Time.deltaTime);
                else
                    transform.position = Vector3.MoveTowards(transform.position, Target, 5 * Time.deltaTime);
                yield return 0;
            }
            Dir = !Dir;
            Speed0 = !Speed0;
            Ready = false;
            yield return new WaitForSeconds(1);
            Ready = true;
        }
    }
    IEnumerator Action01()
    {
        while (true)
        {
            Instantiate(Bullet[2], new Vector3(0, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(12);
        }
    }
    IEnumerator Action01_1()
    {
        while (true)
        {
            for (int x = 1; x < 11; x++)
                Instantiate(Bullet[3], transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 36));
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator Action01_2()
    {
        while (true)
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
            yield return 0;
        }
    }
    IEnumerator Action02()
    {
        while (true)
        {
            if (Num2 < 5)
            {
                Instantiate(Bullet[5], transform.position, Quaternion.Euler(0, 0, 18 + Num2 * 36));
                Num2++;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                Num2 = 0;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator Action02_1()
    {
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-5, 3, 0);
            else
                Target = new Vector3(5, 3, 0);
            while (transform.position != Target)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target, 2 * UnityEngine.Time.deltaTime);
                yield return 0;
            }
            Dir = !Dir;
            Ready = false;
            yield return new WaitForSeconds(0.25f);
            Ready = true;
        }
    }
    IEnumerator Action03()
    {
        while (true)
        {
            for (int x = 1; x < 5; x++)
                Instantiate(Bullet[6], new Vector3(-4.5f, 0, 0), Quaternion.Euler(0, 0, Random.Range(-5, 6) * 5));
            yield return new WaitForSeconds(0.25f);
        }

    }
    IEnumerator Action03_1()
    {
        while (true)
        {
            for (int x = 0; x < 7; x++)
                Instantiate(Bullet[7], new Vector3(4.5f, -4.5f + x * 1.5f, 0), Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Action03_2()
    {
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-5, 3, 0);
            else
                Target = new Vector3(5, 3, 0);
            while (transform.position != Target)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target, 2 * UnityEngine.Time.deltaTime);
                yield return 0;
            }
            Dir = !Dir;
            Ready = false;
            yield return new WaitForSeconds(0.25f);
            Ready = true;
        }
    }
    IEnumerator Action04()
    {
        float AddT = 1;
        for (float t = 0; t < 30; t += AddT)
        {
            if (Change4 == false)
                Instantiate(Bullet[8]);
            else
                Instantiate(Bullet[9]);
            Change4 = !Change4;
            if (t < 10)
            {
                AddT = 1;
                yield return new WaitForSeconds(1);
            }
            else if (t < 20)
            {
                AddT = 0.75f;
                yield return new WaitForSeconds(0.75f);
            }
            else
            {
                AddT = 0.5f;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator Action04_1()
    {
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-5, 4, 0);
            else
                Target = new Vector3(5, 4, 0);
            while (transform.position != Target)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target, 2 * UnityEngine.Time.deltaTime);
                yield return 0;
            }
            Dir = !Dir;
            Ready = false;
            yield return new WaitForSeconds(0.25f);
            Ready = true;
        }
    }
    IEnumerator Action05()
    {
        while (true)
        {
            if (Ready == true)
            {
                int z = Random.Range(-1, 2);
                switch (NowRandom5)
                {
                    case 0: Instantiate(Bullet[10], transform.position, Quaternion.Euler(0, 0, 90 + z * 5)); break;
                    case 1: Instantiate(Bullet[11], transform.position, Quaternion.Euler(0, 0, z * 5)); break;
                    case 2: Instantiate(Bullet[10], transform.position, Quaternion.Euler(0, 0, 90 + z * 5)); break;
                    case 3: Instantiate(Bullet[12], transform.position, Quaternion.Euler(0, 0, z * 5)); break;
                    case 4: Instantiate(Bullet[10], transform.position, Quaternion.Euler(0, 0, 90 + z * 5)); break;
                }
                NowRandom5++;
                if (NowRandom5 > 4)
                    NowRandom5 = 0;
                yield return new WaitForSeconds(0.1f);
            }
            yield return 0;
        }
    }
    IEnumerator Action05_1()
    {
        while (true)
        {
            int y = Random.Range(-2, 3);
            if (Dir == false)
                Target = new Vector3(-6, 3 + y * 0.5f, 0);
            else
                Target = new Vector3(6, 3 + y * 0.5f, 0);
            while (Vector3.Distance(transform.position, Target) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, Target, 3 * UnityEngine.Time.deltaTime);
                yield return 0;
            }
            Dir = !Dir;
            Ready = false;
            yield return new WaitForSeconds(0.25f);
            Ready = true;
        }
    }
}
