using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka5_1 : EnemyBullet
{
    Rigidbody2D Rigid;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }
    protected override IEnumerator Doing()
    {
        transform.Translate(1, 0, 0);
        float p = Random.Range(3, 6);
        Rigid.AddRelativeForce(Vector2.right * p * 0.01f);
        yield return new WaitForSeconds(5);
    }
}
