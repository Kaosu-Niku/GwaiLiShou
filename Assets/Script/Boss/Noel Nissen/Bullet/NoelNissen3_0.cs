using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen3_0 : EnemyBullet
{
    [SerializeField] BulletPool B;
    [SerializeField] GameObject HighChild;
    [SerializeField] GameObject LowChild;
    protected override IEnumerator Doing()
    {
        Speed += Random.Range(-2, 3) * 0.5f;
        int h = Random.Range(0, 10);
        int w = Random.Range(0, 4);
        if (w == 0)
            transform.position = new Vector3(transform.position.x, h * 0.5f, 0);
        else
            transform.position = new Vector3(transform.position.x, -h * 0.5f, 0);
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("TriggerWall"))
        {
            //! 錯誤待修補
            if (transform.position.y > 0)
                B.OutBullet("HighChild", transform.position, Quaternion.identity);
            else
                B.OutBullet("LowChild", transform.position, Quaternion.identity);
        }
    }
}
