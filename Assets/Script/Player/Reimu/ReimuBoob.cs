using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBoob : Bullet
{
    [SerializeField] float AttackTime;
    GameObject MyParent;
    GameObject Player;
    GameObject TheEnemy;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    protected override IEnumerator Doing()
    {
        MyParent = transform.parent.gameObject;
        TheEnemy = GameRunSO.GetFirstEnemy();
        if (Player == true && MyParent == true)
            MyParent.transform.parent = Player.transform;
        for (float t = 0; t < AttackTime; t += Time.deltaTime)
        {
            transform.RotateAround(Player.transform.position, Vector3.back, 100 * Time.deltaTime);
            yield return 0;
        }
        yield return 0;
        while (TheEnemy == true)
        {
            Vector3 dir = TheEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            EnemyBullet e = other.GetComponent<EnemyBullet>();
            if (e)
                e.CallNowClearBullet();
        }
    }
}
