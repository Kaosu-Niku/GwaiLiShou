using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBoob : Bullet
{
    Collider2D Col;
    GameObject Player;
    Coroutine C;
    protected override IEnumerator Doing()
    {
        for (float t = 0; t < 5; t += Time.deltaTime)
        {
            transform.position = Player.transform.position;
            yield return 0;
        }
    }
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (C == null)
                C = StartCoroutine(ColClose());
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            EnemyBullet e = other.GetComponent<EnemyBullet>();
            if (e)
                e.CallNowClearBullet();
        }
    }
    IEnumerator ColClose()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Col.enabled = true;
    }
}
