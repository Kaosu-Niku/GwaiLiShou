using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    protected override IEnumerator CustomAction()
    {
        Vector3 Left = new Vector3(-3.5f, transform.position.y, 0);
        Vector3 Right = new Vector3(3.5f, transform.position.y, 0);
        while (true)
        {
            while (transform.position.x > -3)
            {
                transform.position = Vector3.Lerp(transform.position, Left, Time.deltaTime);
                yield return 0;
            }
            while (transform.position.x < 3)
            {
                transform.position = Vector3.Lerp(transform.position, Right, Time.deltaTime);
                yield return 0;
            }
            yield return 0;
        }
    }
}
