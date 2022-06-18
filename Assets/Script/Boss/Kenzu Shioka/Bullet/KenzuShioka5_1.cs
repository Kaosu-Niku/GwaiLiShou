using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka5_1 : EnemyBullet
{
    Rigidbody2D Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        transform.Translate(1, 0, 0);
        float p = Random.Range(3, 6);
        Rigid.AddRelativeForce(Vector2.right * p * 0.01f);
        Destroy(this.gameObject, 5);
    }
}
