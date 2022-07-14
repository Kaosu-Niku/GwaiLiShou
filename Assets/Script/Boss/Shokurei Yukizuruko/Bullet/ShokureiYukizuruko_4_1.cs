using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_4_1 : EnemyBullet
{
    protected override IEnumerator Doing()
    {
        int r = Random.Range(0, 5);
        Speed += r * 0.5f;
        int w = Random.Range(0, 3);
        float x = Random.Range(-4.5f, 4.5f);
        float y = Random.Range(-5, 5);
        switch (w)
        {
            case 0: transform.position = new Vector3(x, 5, 0); transform.rotation = Quaternion.Euler(0, 0, Random.Range(18, 37) * 10); break;
            case 1: transform.position = new Vector3(-4.5f, y, 0); transform.rotation = Quaternion.Euler(0, 0, 315 + Random.Range(-10, 11)); break;
            case 2: transform.position = new Vector3(4.5f, y, 0); transform.rotation = Quaternion.Euler(0, 0, 225 + Random.Range(-10, 11)); break;
        }
        while (true)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("TriggerWall"))
            Speed = 0.1f;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerWall"))
            gameObject.SetActive(false);
    }
}
