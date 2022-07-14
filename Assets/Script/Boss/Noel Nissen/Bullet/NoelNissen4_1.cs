using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen4_1 : EnemyBullet
{
    protected override IEnumerator Doing()
    {
        yield break;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameRunSO.PlayerMissTrigger();
    }
}
