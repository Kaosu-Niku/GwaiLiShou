using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBulletB1 : Bullet
{
    [SerializeField] int AttackCount;
    [SerializeField] float RotateSpeed;
    protected override IEnumerator Doing()
    {
        yield return 0;
        while (transform.eulerAngles.z < 125)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
            yield return 0;
        }
        yield return new WaitForSeconds(0.3f);
        if (AttackCount > 1)
        {
            while (transform.eulerAngles.z > 55)
            {
                transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
                yield return 0;
            }
            yield return new WaitForSeconds(0.3f);
            if (AttackCount > 2)
            {
                while (transform.eulerAngles.z < 125)
                {
                    transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
                    yield return 0;
                }
                yield return new WaitForSeconds(0.3f);
                if (AttackCount > 3)
                {
                    while (transform.eulerAngles.z > 55)
                    {
                        transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
                        yield return 0;
                    }
                }
            }
        }

    }
}
