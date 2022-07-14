using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarisaBulletB1 : Bullet
{
    Collider2D Col;
    float Dis;
    float DisMagn;
    float NewBulletDamage;
    Coroutine C;
    private void Awake()
    {
        Col = GetComponent<Collider2D>();
    }
    protected override IEnumerator Doing()
    {
        Col.enabled = true;
        yield return new WaitForSeconds(1);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Dis = Vector3.Distance(transform.position, other.transform.position);
            if (Dis > 1 && Dis < 5)
                DisMagn = 1 / Dis * 2;
            else if (Dis >= 5)
                DisMagn = 0.2f;
            else
                DisMagn = 1;
            BulletAttack = (GameDataSO.PlayerPower + GameDataSO.PlayerSkillPower) * BulletMagn * DisMagn;
            base.OnTriggerEnter2D(other);
            if (C == null)
                C = StartCoroutine(ColClose());
        }
    }
    IEnumerator ColClose()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Col.enabled = true;
    }
}
