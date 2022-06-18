using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen5_1 : EnemyBullet
{
    Rigidbody2D Rigid;
    [SerializeField] GameObject Child;
    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        Rigid.AddRelativeForce(Vector2.up * 200);
        while (transform.position.y > 1)
        {
            yield return 0;
        }
        for (int x = 0; x < 16; x++)
            Instantiate(Child, transform.position, Quaternion.Euler(0, 0, x * 22.5f));
        Destroy(this.gameObject);
    }
}
