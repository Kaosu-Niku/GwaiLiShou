using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen4_0 : EnemyBullet
{
    [SerializeField] List<GameObject> Child = new List<GameObject>();
    [SerializeField] bool Change;
    void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        if (Change == false)
            for (int x = 0; x < 15; x += 2)
                Destroy(Child[x]);
        else
            for (int x = 1; x < 14; x += 2)
                Destroy(Child[x]);
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
