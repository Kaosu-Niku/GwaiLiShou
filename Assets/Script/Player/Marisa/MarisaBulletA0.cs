using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletA0 : Bullet
{
    Collider2D Col;
    Coroutine C;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = true;
        yield return new WaitForSeconds(1);
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
