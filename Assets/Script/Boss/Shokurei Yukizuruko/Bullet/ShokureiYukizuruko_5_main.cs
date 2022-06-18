using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_5_main : EnemyBullet
{
    Player GetPlayer;
    private void Start()
    {
        GetPlayer = GameRunSO.Player.GetComponent<Player>();
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        GetPlayer.ResetPoint = transform.position;
        for (float t = 0; t < 7; t += Time.deltaTime)
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
            yield return 0;
        }
        Instantiate(this.gameObject, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
        for (float t = 0; t < 15; t += Time.deltaTime)
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
            yield return 0;
        }
        Destroy(this.gameObject);
    }
}
