using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoelNissen1_0 : EnemyBullet
{
    [SerializeField] List<GameObject> BulletChild = new List<GameObject>();
    float ReadyY;
    bool Ready = false;
    [SerializeField] GameObject Image;
    private void Start()
    {
        ReadyY = transform.position.y - 5;
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        while (transform.position.y > ReadyY)
        {
            transform.Translate(0, -3.5f * Time.deltaTime, 0);
            yield return 0;
        }
        for (int x = 0; x < 8; x++)
        {
            transform.rotation = Quaternion.Euler(0, 0, x * 40);
            Instantiate(BulletChild[0], transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
        }
        transform.rotation = Quaternion.identity;
        for (int x = 1; x < 13; x++)
            Instantiate(BulletChild[1], transform.position, Quaternion.Euler(0, 0, x * 30), transform);
        Destroy(Image);
        while (true)
        {
            transform.Rotate(0, 0, 10 * Time.deltaTime);
            yield return 0;
        }
    }
}
