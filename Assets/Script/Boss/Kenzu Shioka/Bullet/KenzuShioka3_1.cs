using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka3_1 : EnemyBullet
{
    protected override IEnumerator Doing()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
