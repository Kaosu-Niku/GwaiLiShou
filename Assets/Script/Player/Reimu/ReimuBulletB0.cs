using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletB0 : Bullet
{
    protected override IEnumerator Doing()
    {
        while (true)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
            yield return 0;
        }
    }
}
