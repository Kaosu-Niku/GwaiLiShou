using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen2_0 : EnemyBullet
{
    Rigidbody2D Rigid;
    [SerializeField] float Force;
    [SerializeField] GameObject Child;
    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.AddRelativeForce(Vector2.right * Force);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TriggerWall"))
        {
            for (int x = 0; x < 16; x++)
                Instantiate(Child, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 22.5f));
            Destroy(this.gameObject);
        }
    }
}
