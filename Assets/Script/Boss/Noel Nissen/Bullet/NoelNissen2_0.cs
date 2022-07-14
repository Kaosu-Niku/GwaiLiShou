using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen2_0 : EnemyBullet
{
    [SerializeField] BulletPool B;
    Rigidbody2D Rigid;
    [SerializeField] float Force;
    [SerializeField] GameObject Child;
    protected override IEnumerator Doing()
    {
        Rigid.AddRelativeForce(Vector2.right * Force);
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TriggerWall"))
        {
            //! 錯誤待修補
            for (int x = 0; x < 16; x++)
                B.OutBullet("Child", transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 22.5f));
            gameObject.SetActive(false);
        }
    }
}
