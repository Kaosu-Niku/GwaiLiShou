using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletA0 : Bullet
{
    GameObject TheEnemy;
    protected override IEnumerator Doing()
    {
        TheEnemy = GameRunSO.GetFirstEnemy();
        transform.rotation = Quaternion.Euler(0, 0, 90);
        while (TheEnemy == true)
        {
            Vector3 dir = TheEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
