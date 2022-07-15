using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBoom : Bullet
{
    Player player;
    Collider2D Col;
    Coroutine C;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
        player = GameRunSO.Player;
    }
    protected override IEnumerator Doing()
    {
        transform.position = player.transform.position;
        Col.enabled = false;
        yield return new WaitForSeconds(4);
        for (int x = 0; x < 20; x++)
        {
            Col.enabled = true;
            yield return new WaitForSeconds(0.1f);
            Col.enabled = false;
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
