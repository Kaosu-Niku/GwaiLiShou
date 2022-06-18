using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 自選BOSS測試 : MonoBehaviour
{
    [SerializeField] GameObject ChooseBack;
    [SerializeField] List<GameObject> AllBoss = new List<GameObject>();

    void Start()
    {
        Time.timeScale = 0;
    }

    public void ComeOnBoss(int boss)
    {
        Instantiate(AllBoss[boss]);
        Time.timeScale = 1;
        ChooseBack.SetActive(false);
    }
}
