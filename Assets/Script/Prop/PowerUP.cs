using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : Prop
{
    [SerializeField] float Power;
    protected override void Get()
    {
        GameDataSO.PlayerPower += Power;
    }
}
