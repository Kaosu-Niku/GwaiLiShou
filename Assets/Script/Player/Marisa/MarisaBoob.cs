using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBoob : Bullet
{
    Player player;
    Collider2D Col;
    Coroutine C;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
        player = GameRunSO.Player;
        transform.parent = player.transform;
    }
    protected override IEnumerator Doing()
    {
        StartCoroutine(Go());
        yield return new WaitForSeconds(5);
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
    IEnumerator Go()
    {
        Col.enabled = true;
        while (true)
        {
            Col.enabled = true;
            yield return new WaitForSeconds(0.1f);
            Col.enabled = false;
            yield return 0;
        }
    }
}
