using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletA1 : Bullet
{
    Collider2D Col;
    GameObject TheEnemy;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        BulletAttack = GameDataSO.PlayerPower * 2.5f;
        //? 子彈總攻擊力
        if (GameDataSO.PlayerPower == 4)
        {
            transform.localScale = new Vector3(1.7f, 1.7f, 0);
        }
        else if (GameDataSO.PlayerPower >= 3)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 0);
        }
        else if (GameDataSO.PlayerPower >= 2)
        {
            transform.localScale = new Vector3(0.9f, 0.9f, 0);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
        TheEnemy = GameRunSO.GetFirstEnemy();
        transform.rotation = Quaternion.Euler(0, 0, 90);
        StartCoroutine(Go());
        while (TheEnemy)
        {
            transform.position = Vector3.Lerp(transform.position, TheEnemy.transform.position, 3 * Time.deltaTime);
            yield return 0;
        }
    }
    IEnumerator Go()
    {
        Col.enabled = true;
        while (true)
        {
            Col.enabled = true;
            yield return new WaitForSeconds(0.2f);
            Col.enabled = false;
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            effectPool.OutEffect("A1", other.transform.position, Quaternion.identity);
        }
        base.OnTriggerEnter2D(other);
    }
}
