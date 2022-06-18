using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUP : Prop
{
    [SerializeField] int Hp;
    protected override void Get()
    {
        GameDataSO.PlayerHp += Hp;
    }
}
