using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka1_1 : EnemyBullet
{
    protected override IEnumerator Doing()
    {
        transform.Rotate(0, 0, Random.Range(-5, 6));
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}
