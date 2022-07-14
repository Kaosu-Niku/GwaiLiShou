using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen5_1 : EnemyBullet
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
        while (transform.position.y > 1)
        {
            yield return 0;
        }
        //! 錯誤待修補
        for (int x = 0; x < 16; x++)
            B.OutBullet("Child", transform.position, Quaternion.Euler(0, 0, x * 22.5f));
    }
}
