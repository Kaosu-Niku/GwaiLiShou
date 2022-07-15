using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaeBulletA1 : Bullet
{
    Collider2D Col;
    [SerializeField] Collider2D TriggerCol;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = false;
        TriggerCol.enabled = true;
        for (float t = 0; t < 5; t += Time.deltaTime)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
            yield return 0;
        }
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Col.enabled == false)
            {
                float _dis = Vector3.Distance(other.gameObject.transform.position, transform.position);
                if (other.gameObject.transform.position.x < transform.position.x)
                    transform.Rotate(0, 0, 90);
                else
                    transform.Rotate(0, 0, -90);
                TriggerCol.enabled = false;
                Col.enabled = true;
            }
            else
            {
                base.OnTriggerEnter2D(other);
                gameObject.SetActive(false);
            }
        }
    }
}
