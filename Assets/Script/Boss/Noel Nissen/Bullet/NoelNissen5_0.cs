using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen5_0 : EnemyBullet
{
    Rigidbody2D Rigid;
    [SerializeField] float Force;
    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.AddRelativeForce(Vector2.right * Force);
    }
}
