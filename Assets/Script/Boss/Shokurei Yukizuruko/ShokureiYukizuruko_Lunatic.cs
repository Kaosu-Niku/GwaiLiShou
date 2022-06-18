using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_Lunatic : Boss
{
    GameObject Obj3;

    protected override void NewRoundFirst()
    {
        switch (Round)
        {
            case 4:
                Destroy(Obj3);
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.identity);
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 180));
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 270));
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
                NowAction.Add(StartCoroutine(FourOneAction()));
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
            Instantiate(Bullet[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
    IEnumerator TwoAction()
    {
        while (true)
        {
            Instantiate(Bullet[1]);
            Instantiate(Bullet[2]);
            yield return new WaitForSeconds(13);
        }
    }
    IEnumerator ThreeAction()
    {
        while (true)
        {
            Instantiate(Bullet[3], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
    IEnumerator FourAction()
    {
        Reset = new Vector3(0, 0, 0);
        Obj3 = Instantiate(Bullet[5], GameRunSO.Player.transform.position, Quaternion.identity, GameRunSO.Player.transform);
        while (true)
        {
            for (int x = 1; x < 10; x++)
                Instantiate(Bullet[6]);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator FourOneAction()
    {
        while (true)
        {
            Vector3 dir = GameRunSO.Player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            for (int x = 0; x < 5; x++)
                Instantiate(Bullet[7], transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 72));
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator FiveAction()
    {
        while (true)
        {
            Vector3 dir = GameRunSO.Player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            for (int x = 0; x < 4; x++)
                Instantiate(Bullet[9], transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 90));
            yield return new WaitForSeconds(0.25f);
        }
    }
}
