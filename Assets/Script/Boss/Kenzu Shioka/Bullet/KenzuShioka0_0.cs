using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka0_0 : EnemyBullet
{
    private void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
