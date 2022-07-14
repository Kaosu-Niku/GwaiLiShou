using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletA0 : Bullet
{
    Player player;
    Collider2D Col;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
        player = GameRunSO.Player;
        transform.parent = player.transform;
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = true;
        while (true)
        {
            Col.enabled = true;
            yield return new WaitForSeconds(0.1f);
            Col.enabled = false;
            yield return 0;
        }
    }
}
