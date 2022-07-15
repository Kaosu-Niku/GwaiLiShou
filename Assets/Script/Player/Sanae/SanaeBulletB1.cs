using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBulletB1 : Bullet
{
    [SerializeField] float RotateSpeed;
    protected override IEnumerator Doing()
    {
        yield return 0;
        while (transform.eulerAngles.z < 150)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
            yield return 0;
        }
        while (transform.eulerAngles.z > 30)
        {
            transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
            yield return 0;
        }
        while (transform.eulerAngles.z < 150)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
            yield return 0;
        }
        while (transform.eulerAngles.z > 30)
        {
            transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
            yield return 0;
        }
    }
}
