using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 編輯者模式 : MonoBehaviour
{
    [SerializeField] float 改變運行時間;
    private void Awake()
    {
        AllEventSO.ChangeTime(改變運行時間);
    }
}
