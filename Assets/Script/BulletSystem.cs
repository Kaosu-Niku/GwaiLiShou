using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletSystem : MonoBehaviour
{
    [HideInInspector] public BulletPool MyPool;
    [HideInInspector] public string MyTag;
    Coroutine C;
    protected abstract IEnumerator FirstDoing();
    private IEnumerator Do()
    {
        yield return StartCoroutine(FirstDoing());
        gameObject.SetActive(false);
    }
    protected void OnEnable()
    {
        C = StartCoroutine(Do());
    }
    protected void OnDisable()
    {
        if (C != null)
        {
            StopCoroutine(C);
        }
        MyPool.InBullet(MyTag, this);
    }
}
