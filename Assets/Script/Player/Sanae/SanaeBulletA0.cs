using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBulletA0 : Bullet
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            MyPool.OutBullet("A0C0", transform.position, Quaternion.identity);
        }
        base.OnTriggerEnter2D(other);
    }
}
