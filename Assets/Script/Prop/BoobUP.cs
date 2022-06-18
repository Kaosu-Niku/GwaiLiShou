using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoobUP : Prop
{
    [SerializeField] int Bomb;
    protected override void Get()
    {
        GameDataSO.PlayerBomb += Bomb;
    }
}
