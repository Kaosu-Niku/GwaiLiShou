using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletA1 : Bullet
{
    Collider2D Col;
    GameObject TheEnemy;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = true;
        TheEnemy = GameRunSO.GetFirstEnemy();
        transform.rotation = Quaternion.Euler(0, 0, 90);
        StartCoroutine(Go());
        while (TheEnemy)
        {
            Vector3 dir = TheEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    IEnumerator Go()
    {
        while (true)
        {
            Col.enabled = true;
            yield return new WaitForSeconds(0.1f);
            Col.enabled = false;
            yield return 0;
        }
    }
}
