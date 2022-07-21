using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletA0 : Bullet
{
    GameObject TheEnemy;
    float DefaultSpeed;
    protected override IEnumerator Doing()
    {
        TheEnemy = null;
        while (true)
        {
            if (TheEnemy == null)
            {
                TheEnemy = GameRunSO.GetFirstEnemy();
            }
            else
            {
                Quaternion nowEuler = transform.rotation;//取得物件原本的角度
                Vector3 dir = TheEnemy.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Quaternion lookEuler = transform.rotation;//取得看向目標後的角度
                transform.rotation = nowEuler;//物件還原到原本的角度
                float lookAngle = Quaternion.Angle(nowEuler, lookEuler);//取得原始與看向目標，兩角度的夾角
                transform.rotation = Quaternion.Lerp(nowEuler, lookEuler, 8 * Time.deltaTime);
            }
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            effectPool.OutEffect("A1", transform.position, Quaternion.identity);
        }
        base.OnTriggerEnter2D(other);
    }
}
