using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 彈幕測試用 : MonoBehaviour
{

    public void 彈幕測試()
    {
        GameDataSO.PlayerStartHP = 10;
        GameDataSO.PlayerStartBomb = 3;
        GameDataSO.PlayerStartPower = 5;
        GameDataSO.Score = 0;
        GameDataSO.Point = 0;
        GameDataSO.Graze = 0;
        AllEventSO.ChangeScene("測試用場景");
    }
    public void 自選BOSS測試()
    {
        GameDataSO.PlayerStartHP = 10;
        GameDataSO.PlayerStartBomb = 3;
        GameDataSO.PlayerStartPower = 5;
        GameDataSO.Score = 0;
        GameDataSO.Point = 0;
        GameDataSO.Graze = 0;
        AllEventSO.ChangeScene("自選BOSS測試用場景");
    }
}
