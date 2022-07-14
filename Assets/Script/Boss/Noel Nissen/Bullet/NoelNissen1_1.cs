using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen1_1 : EnemyBullet
{
    protected override IEnumerator Doing()
    {
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
