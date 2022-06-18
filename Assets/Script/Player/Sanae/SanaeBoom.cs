using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBoom : Bullet
{
    Collider2D Col;
    private void Start()
    {
        StartCoroutine(StartTime());
    }
    IEnumerator StartTime()
    {
        Col = GetComponent<Collider2D>();
        Col.enabled = false;
        yield return new WaitForSeconds(4);
        Col.enabled = true;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            StartCoroutine(ColClose());
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            EnemyBullet e = other.GetComponent<EnemyBullet>();
            if (e)
                e.NowDestroyBullet();
        }
    }
    IEnumerator ColClose()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Col.enabled = true;
    }
}
