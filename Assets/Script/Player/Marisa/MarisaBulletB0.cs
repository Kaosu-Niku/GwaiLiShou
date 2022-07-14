using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletB0 : Bullet
{
    protected override IEnumerator Doing()
    {
        while (true)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
            yield return 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //! 錯誤待修補 
            MyPool.OutBullet("這顆子彈", transform.position, Quaternion.identity);
        }
    }
}
