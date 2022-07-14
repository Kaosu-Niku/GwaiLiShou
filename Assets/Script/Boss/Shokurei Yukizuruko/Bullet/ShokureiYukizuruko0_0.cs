using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko0_0 : EnemyBullet
{
    [SerializeField] BulletPool B;
    [SerializeField] float Long;
    Vector3 ReadyPos;
    [SerializeField] float ReadyTime;
    [SerializeField] bool Which;
    Transform GetPlayer;
    [SerializeField] GameObject Child;
    private void Awake()
    {
        GetPlayer = GameRunSO.Player.transform;
    }
    protected override IEnumerator Doing()
    {
        ReadyPos = new Vector3(transform.position.x + Long, transform.position.y, 0);
        yield return new WaitForSeconds(ReadyTime);
        for (float a = 0; a < 3; a += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, ReadyPos, Speed * Time.deltaTime);
            yield return 0;
        }
        Vector3 dir = GetPlayer.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //! 錯誤待修補
        if (Which == false)
        {
            for (int x = 0; x < 18; x++)
                B.OutBullet("Child", transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + x * 20));
        }
        else
        {
            for (int x = 0; x < 18; x++)
                B.OutBullet("Child", transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + 10 + x * 20));
        }
    }
}
