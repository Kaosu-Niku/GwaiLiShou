using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHpUP : Prop
{
    [SerializeField] int SmallHp;
    protected override void Get()
    {
        GameDataSO.PlayerSmallHp += SmallHp;
    }
}
