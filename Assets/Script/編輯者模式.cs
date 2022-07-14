using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 編輯者模式 : MonoBehaviour
{
    [SerializeField] List<Player> AllPlayer = new List<Player>();//? 根據選項生成對應機體
    [SerializeField] float 改變運行時間;
    public int 預設玩家;
    private void Awake()
    {
        AllEventSO.ChangeTime(改變運行時間);
        Instantiate(AllPlayer[預設玩家]);
    }
}
