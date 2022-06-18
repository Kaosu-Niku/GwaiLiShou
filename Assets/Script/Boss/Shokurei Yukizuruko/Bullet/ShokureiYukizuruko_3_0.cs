using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_3_0 : EnemyBullet
{   
    private void Start()
    {
        StartCoroutine(Move());
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("TriggerWall"))
            Destroy(this.gameObject);
    }
    IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }

    }
}
