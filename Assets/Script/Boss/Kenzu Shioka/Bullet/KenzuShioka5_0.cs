using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka5_0 : EnemyBullet
{
    private void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        Speed = Random.Range(0.5f, 0.8f);
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
