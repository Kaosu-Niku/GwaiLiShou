using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyPoolDataSO enemyPoolData;
    Queue<Enemy> AllEnemy = new Queue<Enemy>();
    Queue<float> AllStartTime = new Queue<float>();
    Coroutine C;
    float NowTime;
    float NextTime;
    bool _Stop;//? 用於控制遊戲進度流程，該值為true可使進度中斷，必須等到該值為false才能繼續進度(適用於中型妖精或是道中BOSS等不擊破就不會推進進度的敵人)
    bool Stop { get => _Stop; set { _Stop = value; if (_Stop == true) { if (C != null) { StopCoroutine(C); C = null; } } else { if (C == null) C = StartCoroutine(Go()); } } }
    private void StopEnemyPool(bool b)
    {
        Stop = b;
    }
    private void OnEnable()
    {
        GameRunSO.StopEnemyPoolAction += StopEnemyPool;
    }
    private void OnDisable()
    {
        GameRunSO.StopEnemyPoolAction -= StopEnemyPool;
    }
    private void Start()
    {
        for (int x = 0; x < enemyPoolData.AllEnemyData.Count; x++)
        {
            Enemy e = Instantiate(enemyPoolData.AllEnemyData[x].Who, enemyPoolData.AllEnemyData[x].StartPos, Quaternion.identity);
            AllStartTime.Enqueue(enemyPoolData.AllEnemyData[x].StartTime);
            AllEnemy.Enqueue(e);
            e.gameObject.SetActive(false);
        }
        NextTime = AllStartTime.Dequeue();
        Stop = false;
    }
    IEnumerator Go()
    {
        while (true)
        {
            NowTime += Time.deltaTime;
            while (NowTime > NextTime)
            {
                if (AllEnemy.Count > 0)
                {
                    Enemy e = AllEnemy.Dequeue();
                    e.gameObject.SetActive(true);
                    if (AllStartTime.Count > 0)
                        NextTime = AllStartTime.Dequeue();
                    else
                        yield break;
                }
                else
                {
                    yield break;
                }
            }
            yield return 0;
        }
    }
}
