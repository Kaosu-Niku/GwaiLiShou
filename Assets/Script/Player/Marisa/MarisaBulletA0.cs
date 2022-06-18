using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletA0 : Bullet
{
    Collider2D Col;
    private void OnEnable()
    {
        Col = GetComponent<Collider2D>();
        Col.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            StartCoroutine(ColClose());
    }

    IEnumerator ColClose()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Col.enabled = true;
    }
}
