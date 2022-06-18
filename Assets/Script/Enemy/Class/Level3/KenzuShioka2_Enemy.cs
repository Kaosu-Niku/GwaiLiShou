using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenzuShioka2_Enemy : Enemy
{
    [SerializeField] GameObject Bullet;
    protected override IEnumerator StartAction()//? 敵人自定義行動
    {
        while (true)
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, Speed * Time.deltaTime);
            yield return 0;
        }
    }
    IEnumerator Go()
    {
        while (true)
        {
            Vector3 dir = GetPlayer.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            for (int x = 0; x < 10; x++)
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 36));
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void Start()
    {
        StartCoroutine(Go());
    }
}
