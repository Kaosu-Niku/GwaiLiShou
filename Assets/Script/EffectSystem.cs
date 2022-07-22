using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    [SerializeField] float CloseTime = 5;
    [HideInInspector] public EffectPool MyPool;
    [HideInInspector] public string MyTag;
    Coroutine C;
    //? 監聽動畫事件做關閉
    public void AnimationEventTrigger()
    {
        gameObject.SetActive(false);
    }
    //? 指定時間自行關閉
    IEnumerator Close()
    {
        yield return new WaitForSeconds(CloseTime);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        C = StartCoroutine(Close());
    }
    private void OnDisable()
    {
        if (C != null)
            StopCoroutine(C);
    }
}
