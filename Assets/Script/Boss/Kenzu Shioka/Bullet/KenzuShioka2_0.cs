using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka2_0 : EnemyBullet
{
    private void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        Vector3 dir = GameRunSO.Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
