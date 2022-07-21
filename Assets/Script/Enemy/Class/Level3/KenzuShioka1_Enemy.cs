using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka1_Enemy : Enemy
{
    [SerializeField] Vector3 Target;
    [SerializeField] bool Dir;
    [SerializeField] GameObject Bullet;
    protected override IEnumerator CustomAction()
    {
        while (true)
        {
            while (transform.position != Target)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
                yield return 0;
            }
            if (Dir == false)
                Target = new Vector3(4, 4.5f, 0);
            else
                Target = new Vector3(-4, 4.5f, 0);
            Dir = !Dir;
            yield return 0;
        }
    }
    IEnumerator Go()
    {
        while (true)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void Start()
    {
        StartCoroutine(Go());
    }
}
