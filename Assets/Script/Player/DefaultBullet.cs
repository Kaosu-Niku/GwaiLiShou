using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : Bullet
{
    [SerializeField] float ClearTime;
    protected override IEnumerator Doing()
    {
        yield return new WaitForSeconds(ClearTime);
    }
}
