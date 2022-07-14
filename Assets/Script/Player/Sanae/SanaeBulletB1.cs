using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBulletB1 : Bullet
{
    [SerializeField] float RotateSpeed;
    int RotateCount;
    protected override IEnumerator Doing()
    {
        transform.rotation = Quaternion.Euler(0, 0, 30);
        while (true)
        {
            switch (RotateCount)
            {
                case 0:
                    if (transform.eulerAngles.z < 150)
                        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
                    else
                        RotateCount++;
                    break;
                case 1:
                    if (transform.eulerAngles.z > 30)
                        transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
                    else
                        RotateCount++;
                    break;
                case 2:
                    if (transform.eulerAngles.z < 150)
                        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
                    else
                        RotateCount++;
                    break;
                case 3:
                    if (transform.eulerAngles.z > 30)
                        transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
                    else
                        Destroy(this.gameObject);
                    break;
            }
            yield return 0;
        }
    }
}
