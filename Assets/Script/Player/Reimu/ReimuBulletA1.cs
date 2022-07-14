using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletA1 : Bullet
{
    Collider2D Col;
    GameObject TheEnemy;
    Coroutine C;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = true;
        TheEnemy = GameRunSO.GetFirstEnemy();
        transform.rotation = Quaternion.Euler(0, 0, 90);
        while (TheEnemy)
        {
            Vector3 dir = TheEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, TheEnemy.transform.position, 10 * Time.deltaTime);
            yield return 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (C == null)
                C = StartCoroutine(ColClose());
        }
    }
    IEnumerator ColClose()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Col.enabled = true;
    }
}
