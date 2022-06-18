using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen5_2 : EnemyBullet
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
        while (transform.position.y > -4.5f)
        {
            yield return 0;
        }
        Instantiate(Child, transform.position, Quaternion.Euler(0, 0, 90));
        Destroy(this.gameObject);
    }
}
