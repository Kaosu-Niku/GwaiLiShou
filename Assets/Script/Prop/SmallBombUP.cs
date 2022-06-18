using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBombUP : Prop
{
    [SerializeField] int SmallBomb;
    protected override void Get()
    {
        GameDataSO.PlayerSmallBomb += SmallBomb;
    }
}
