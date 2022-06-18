using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 測試用BOSS : Boss
{
    bool Dir2;
    protected override void NewRoundFirst()
    {
        switch (Round)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
        }
    }
    protected override IEnumerator NewRoundAction()
    {
        switch (Round)
        {
            case 0:
                NowAction.Add(StartCoroutine(OneAction()));
                break;
            case 1:
                NowAction.Add(StartCoroutine(TwoAction()));
                break;
            case 2:
                NowAction.Add(StartCoroutine(ThreeAction()));
                break;
            case 3:
                NowAction.Add(StartCoroutine(FourAction()));
                break;
            case 4:
                NowAction.Add(StartCoroutine(FiveAction()));
                break;
        }
        yield break;
    }
    IEnumerator OneAction()
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
    IEnumerator TwoAction()
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
    IEnumerator ThreeAction()
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
    IEnumerator FourAction()
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
    IEnumerator FourOneAction()
    {
        while (true)
        {
            yield return 0;
        }
    }
    IEnumerator FiveAction()
    {
        while (true)
        {
            yield return 0;
        }
    }
}
