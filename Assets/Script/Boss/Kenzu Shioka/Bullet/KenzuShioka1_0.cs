using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka1_0 : EnemyBullet
{
    [SerializeField] bool Dir;
    [SerializeField] Transform Middle;
    [SerializeField] GameObject ChildBullet;
    private void Start()
    {
        StartCoroutine(Go());
        StartCoroutine(Go2());
    }
    IEnumerator Go()
    {
        while (true)
        {
            if (Dir == false)
                transform.RotateAround(Middle.position, Vector3.forward, Speed * Time.deltaTime);
            else
                transform.RotateAround(Middle.position, Vector3.back, Speed * Time.deltaTime);
            yield return 0;
        }
    }
    IEnumerator Go2()
    {
        while (true)
        {
            for (int x = 0; x < 30; x++)
            {
                Instantiate(ChildBullet, transform.position, transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5);
        }
    }
}
