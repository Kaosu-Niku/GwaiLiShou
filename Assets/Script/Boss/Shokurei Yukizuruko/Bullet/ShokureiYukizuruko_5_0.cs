using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_5_0 : EnemyBullet
{
    [SerializeField] float ShootTime;
    protected override IEnumerator Doing()
    {
        transform.Translate(-3, 0, 0);
        for (float t = 0; t < 3; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, 0.15f * Time.deltaTime);
            yield return 0;
        }
        yield return new WaitForSeconds(ShootTime - 3);
        for (float t = 0; t < 5; t += Time.deltaTime)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}
