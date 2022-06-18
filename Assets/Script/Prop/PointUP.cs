using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUP : Prop
{
    [SerializeField] int Point;
    protected override void Get()
    {
        GameDataSO.Score += Point;
        GameDataSO.Point += Point;
    }
}
