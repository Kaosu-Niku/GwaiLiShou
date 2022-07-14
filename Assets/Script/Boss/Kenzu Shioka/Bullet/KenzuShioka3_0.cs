using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka3_0 : EnemyBullet
{
    [SerializeField] GameObject Child;
    Transform Pos0, Pos1;
    protected override IEnumerator Doing()
    {
        StartCoroutine(Go());
        Pos0 = transform.GetChild(1).transform;
        Pos1 = transform.GetChild(2).transform;
        while (true)
        {
            Instantiate(Child, Pos0.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
            Instantiate(Child, Pos1.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
            Instantiate(Child, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Go()
    {
        while (transform.position.y > -4.5f)
        {
            yield return 0;
        }
        gameObject.SetActive(false);
    }
}
