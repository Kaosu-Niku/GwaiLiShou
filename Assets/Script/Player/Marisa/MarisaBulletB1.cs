using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletB1 : Bullet
{
    Player player;
    private void Awake()
    {
        player = GameRunSO.Player;
    }
    protected override IEnumerator Doing()
    {
        Speed = 7.5f;
        BulletAttack = 2;
        for (float x = 0; x < 0.5f; x += Time.deltaTime)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
        for (float x = 0; x < 0.5f; x += Time.deltaTime)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            Speed -= Time.deltaTime * 15;
            yield return 0;
        }
    }
}
