using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_Lunatic : Boss
{
    GameObject Obj3;
    protected override void BossResetAction()
    {
        switch (Stage)
        {
            case 0: AddBossStartAction(Action00()); break;
            case 1: AddBossStartAction(Action01()); break;
            case 2: AddBossStartAction(Action02()); break;
            case 3: AddBossStartAction(Action03()); AddBossStartAction(Action03_1()); break;
            case 4:
                AddBossStartAction(Action04());
                Destroy(Obj3);
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.identity);
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 180));
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
                Instantiate(Bullet[8], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 270));
                break;
        }
    }
    IEnumerator Action00()
    {
        while (true)
        {
            Instantiate(Bullet[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
    IEnumerator Action01()
    {
        while (true)
        {
            Instantiate(Bullet[1]);
            Instantiate(Bullet[2]);
            yield return new WaitForSeconds(13);
        }
    }
    IEnumerator Action02()
    {
        while (true)
        {
            Instantiate(Bullet[3], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
    IEnumerator Action03()
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
    IEnumerator Action03_1()
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
    IEnumerator Action04()
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
