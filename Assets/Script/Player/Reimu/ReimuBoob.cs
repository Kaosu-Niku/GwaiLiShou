using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBoob : Bullet
{
    Player player;
    GameObject TheEnemy;
    private void Awake()
    {
        player = GameRunSO.Player;
    }
    protected override IEnumerator Doing()
    {
        yield return 0;
        for (float t = 0; t < 4; t += Time.deltaTime)
        {
            transform.position = player.transform.position;
            transform.Translate(1, 0, 0);
            transform.Rotate(0, 0, 100 * Time.deltaTime);
            yield return 0;
        }
        for (float t = 0; t < 3; t += Time.deltaTime)
        {
            if (TheEnemy != null)
            {
                if (Vector3.Distance(TheEnemy.transform.position, transform.position) > 0.1f)
                {
                    Vector3 dir = TheEnemy.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.Translate(Speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    yield break;
                }
            }
            else
            {
                TheEnemy = GameRunSO.GetFirstEnemy();
            }
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            EnemyBullet e = other.GetComponent<EnemyBullet>();
            if (e)
                e.CallNowClearBullet();
        }
        base.OnTriggerEnter2D(other);
    }
}
