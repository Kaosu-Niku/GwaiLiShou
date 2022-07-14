using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_1_0 : EnemyBullet
{
    [SerializeField] bool Dir;//* 左方還是右方
    float FirstHigh;//* 起始高度
    int High;//* 在高處或低處
    int Move;//* 高度變化隨機範圍
    Vector3 FirstPos;//* 第一次定位
    Vector3 TwoPos;//* 第二次定位
    float OverTime;//* 差值計時
    protected override IEnumerator Doing()
    {
        OverTime = 0;
        FirstHigh = transform.position.y;
        High = Random.Range(0, 2);
        Move = Random.Range(1, 5);
        if (High == 0)
            transform.Translate(0, -Move * 0.2f, 0);
        else
            transform.Translate(0, Move * 0.2f, 0);
        if (Dir == false)
            FirstPos = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        else
            FirstPos = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        while (transform.position != FirstPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, FirstPos, Speed * Time.deltaTime);
            yield return 0;
        }
        yield return new WaitForSeconds(1);
        if (High == 0)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        else
            transform.rotation = Quaternion.Euler(0, 0, 270);
        TwoPos = new Vector3(transform.position.x, FirstHigh, transform.position.z);
        yield return new WaitForSeconds(2);
        while (transform.position != TwoPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, TwoPos, Speed * Move / 10 * Time.deltaTime);
            OverTime += Time.deltaTime;
            yield return 0;
        }
        transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(3 - OverTime);
        while (true)
        {
            if (Dir == false)
                transform.Translate(Speed * 3 * Time.deltaTime, 0, 0);
            else
                transform.Translate(-Speed * 3 * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
}

