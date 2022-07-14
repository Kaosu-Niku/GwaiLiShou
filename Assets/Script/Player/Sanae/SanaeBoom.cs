using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBoom : Bullet
{
    Collider2D Col;
    Coroutine C;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(4);
        Col.enabled = true;
        yield return new WaitForSeconds(2);
    }
    void OnTriggerStay2D(Collider2D other)
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
