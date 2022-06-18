using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShokureiYukizuruko_3_1 : MonoBehaviour
{
    float NowX;
    float NowY;
    private void Start()
    {
        StartCoroutine(ScaleSmallIEnum());
    }
    IEnumerator ScaleSmallIEnum()
    {
        while (true)
        {
            NowX = transform.localScale.x;
            NowY = transform.localScale.y;
            yield return new WaitForSeconds(4);
            for (float x = 0; x < 1; x += Time.deltaTime)
            {
                transform.localScale = new Vector3(NowX - x / 10, NowY - x / 10, 1);
                yield return 0;
            }
            yield return 0;
        }
    }
}
