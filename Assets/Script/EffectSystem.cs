using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    [HideInInspector] public EffectPool MyPool;
    [HideInInspector] public string MyTag;
    public void AnimationEventTrigger()
    {
        gameObject.SetActive(false);
        MyPool.InEffect(MyTag, this);
    }
}
