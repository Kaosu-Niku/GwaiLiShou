using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen5_2 : EnemyBullet
{
    [SerializeField] BulletPool B;
    Rigidbody2D Rigid;
    [SerializeField] GameObject Child;
    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }
    protected override IEnumerator Doing()
    {
        Rigid.AddRelativeForce(Vector2.up * 200);
        while (transform.position.y > -4.5f)
        {
            yield return 0;
        }
        B.OutBullet("Child", transform.position, Quaternion.Euler(0, 0, 90));
    }
}
