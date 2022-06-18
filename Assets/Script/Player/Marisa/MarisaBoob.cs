using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBoob : Bullet
{
    Collider2D Col;
    GameObject Player;
    private void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        Col = GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        for (float t = 0; t < 5; t += Time.deltaTime)
        {
            transform.position = Player.transform.position;
            yield return 0;
        }
        Destroy(this.gameObject);
        yield break;
    }
    private void OnTriggerStay2D(Collider2D other)
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
