using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBulletA1 : Bullet
{
    protected override IEnumerator Doing()
    {
        for (float t = 0; t < 3; t += Time.deltaTime)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            float _dis = Vector3.Distance(other.gameObject.transform.position, transform.position);
            if (other.gameObject.transform.position.x < transform.position.x)
                MyPool.OutBullet("A1C0", transform.position + Vector3.up, Quaternion.Euler(0, 0, 180));
            else
                MyPool.OutBullet("A1C0", transform.position + Vector3.up, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
