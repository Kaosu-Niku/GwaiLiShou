using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_3_0 : EnemyBullet
{
    protected override IEnumerator Doing()
    {
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("TriggerWall"))
            gameObject.SetActive(false);
    }
}
