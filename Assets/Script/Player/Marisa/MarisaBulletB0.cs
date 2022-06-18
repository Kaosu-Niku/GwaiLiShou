using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletB0 : Bullet
{
    [SerializeField] GameObject ChildBullet;
    private void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        while (true)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
            yield return 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(ChildBullet, transform.position, Quaternion.identity);
        }
    }
}
