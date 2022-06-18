using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] float _time;
    void Start()
    {
        Destroy(this.gameObject,_time);
    }
}
