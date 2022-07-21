using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka_Lunatic : Boss
{
    //* 單一
    Rigidbody2D Rigid;
    [SerializeField] Collider2D MyCol;
    [SerializeField] Collider2D MyCol5;
    bool Ready;
    bool Dir = false;
    Vector3 Target;
    GameObject Obj0;
    GameObject Obj1;
    GameObject Obj1_1;
    GameObject Obj2;
    Vector3 RePos3 = new Vector3(0, 3, 0);
    Vector3 FollowPos3;
    bool Dir3 = false;
    bool CanShoot3 = false;
    GameObject Obj4;
    GameObject Obj5;
    Collider2D PlayerCol;
    bool Get5 = false;
    bool CanDo5 = true;
    protected override void BossResetAction()
    {
        Rigid = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.identity;
        Rigid.gravityScale = 0;
        Rigid.Sleep();
        switch (Stage)
        {
            case 0:
                AddBossStartAction(Action00());
                break;
            case 1:
                AddBossStartAction(Action01());
                Destroy(Obj0);
                GetPlayer.ResetPoint = new Vector3(0, 0, 0);
                break;
            case 2:
                AddBossStartAction(Action02());
                Destroy(Obj1);
                Destroy(Obj1_1);
                GetPlayer.ResetPoint = new Vector3(0, -3.5f, 0);
                break;
            case 3:
                AddBossStartAction(Action03());
                AddBossStartAction(Action03_1());
                Destroy(Obj2);
                break;
            case 4:
                AddBossStartAction(Action04());
                break;
            case 5:
                AddBossStartAction(Action05());
                Destroy(Obj4);
                Obj5 = Instantiate(Bullet[2]);
                MyCol.enabled = false;
                MyCol5.enabled = true;
                GetPlayer.ResetPoint = new Vector3(0, 0, 0);
                PlayerCol = GetPlayer.GetComponent<Collider2D>();
                break;
            case 6:
                AddBossStartAction(Action06());
                Destroy(Obj5);
                Get5 = false;
                MyCol.enabled = true;
                MyCol5.enabled = false;
                Rigid.Sleep();
                GetPlayer.ResetPoint = new Vector3(0, -3.5f, 0);
                GameRunSO.ForPlayerDontControlTrigger(false);
                break;
        }
    }
    IEnumerator Action00()
    {
        Obj0 = Instantiate(Bullet[5]);
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-4, 3, 0);
            else
                Target = new Vector3(4, 3, 0);
            while (Vector3.Distance(transform.position, Target) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, Target, Time.deltaTime);
                yield return 0;
            }
            Dir = !Dir;
            Ready = false;
            yield return new WaitForSeconds(0.25f);
            Ready = true;
        }
    }
    IEnumerator Action01()
    {
        Obj1 = Instantiate(Bullet[7]);
        Obj1_1 = Instantiate(Bullet[8]);
        while (true)
        {
            transform.Translate(5 * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    IEnumerator Action02()
    {
        Obj2 = Instantiate(Bullet[6]);
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-4, 3, 0);
            else
                Target = new Vector3(4, 3, 0);
            while (Vector3.Distance(transform.position, Target) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, Target, Time.deltaTime);
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
            CanShoot3 = true;
            FollowPos3 = new Vector3(GameRunSO.Player.transform.position.x, transform.position.y, 0);
            if (transform.position.x > GameRunSO.Player.transform.position.x)
            {
                Dir3 = false;
                Instantiate(Bullet[0], transform.position, Quaternion.Euler(0, 180, 0), transform);
            }
            else
            {
                Dir3 = true;
                Instantiate(Bullet[0], transform.position, Quaternion.identity, transform);
            }
            Rigid.gravityScale = 1;
            Rigid.AddForce(Vector2.up * 0.05f);
            while (transform.position.y > -5)
            {
                if (transform.position.y > FollowPos3.y)
                    transform.position = Vector3.Lerp(transform.position, FollowPos3, Time.deltaTime);
                if (transform.eulerAngles.z < 175 || transform.eulerAngles.z > 185)
                {
                    if (Dir3 == false)
                        transform.Rotate(0, 0, 100 * Time.deltaTime);
                    else
                        transform.Rotate(0, 0, -100 * Time.deltaTime);
                }
                yield return 0;
            }
            transform.rotation = Quaternion.identity;
            Rigid.gravityScale = 0;
            Rigid.Sleep();
            RePos3 = new Vector3(transform.position.x, 3, 0);
            while (Vector3.Distance(transform.position, RePos3) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, RePos3, 5 * Time.deltaTime);
                yield return 0;
            }
            CanShoot3 = false;
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator Action03_1()
    {
        while (true)
        {
            if (CanShoot3 == true)
                Instantiate(Bullet[1], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Action04()
    {
        Obj4 = Instantiate(Bullet[9]);
        while (true)
        {
            if (Dir == false)
                Target = new Vector3(-4, 3, 0);
            else
                Target = new Vector3(4, 3, 0);
            while (Vector3.Distance(transform.position, Target) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, Target, Time.deltaTime);
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
        Rigid.gravityScale = 1;
        while (true)
        {
            if (Get5 == true)
                GameRunSO.Player.transform.position = transform.position;
            yield return 0;
        }
    }
    IEnumerator Action06()
    {
        Rigid.gravityScale = 1;
        while (true)
        {
            if (Get5 == true)
                GameRunSO.Player.transform.position = transform.position;
            yield return 0;
        }
    }

    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (Stage == 1)
        {
            if (other.gameObject.CompareTag("TriggerWall"))
            {
                Vector3 dir = GetPlayer.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            if (other.gameObject.CompareTag("Wall"))
            {
                Vector3 dir = GetPlayer.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Stage == 5)
        {
            if (other.gameObject.CompareTag("Player"))//? 碰到玩家使玩家跟著boss移動、關閉玩家碰撞體、使玩家無法控制)  
            {
                Get5 = true;
                PlayerCol.enabled = false;
                GameRunSO.ForPlayerDontControlTrigger(true);
            }
            if (other.gameObject.CompareTag("TriggerWall") && CanDo5 == true)
                StartCoroutine(GetPlayer5());
        }
    }
    IEnumerator GetPlayer5()//? 落地後的行為
    {
        CanDo5 = false;
        if (Get5 == true)//? 有抓住玩家就使玩家Miss、歸還玩家控制、3秒後開啟玩家碰撞體並重新行動  
        {
            Get5 = false;
            GameRunSO.PlayerMissTrigger();
            GameRunSO.ForPlayerDontControlTrigger(false);
            for (int x = 0; x < 37; x++)
                Instantiate(Bullet[4], transform.position, Quaternion.Euler(0, 0, x * 5));
            yield return new WaitForSeconds(3);
        }
        else
        {
            for (int x = 0; x < 60; x++)
                Instantiate(Bullet[3], transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 6));
            yield return 0;
        }
        PlayerCol.enabled = true;
        Vector3 dir = GameRunSO.Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigid.Sleep();
        yield return 0;
        Rigid.AddRelativeForce(Vector2.right * 0.1f);
        yield return 0;
        CanDo5 = true;
        yield break;
    }
}
