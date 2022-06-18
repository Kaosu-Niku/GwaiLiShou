using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGetProp : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GetProp"))
            GameRunSO.PlayerTouchAutoGetPropTrigger(other.transform.root.transform);
    }
}
