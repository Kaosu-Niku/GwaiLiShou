using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    [HideInInspector] public Transform Target;
    [SerializeField] float Force;
    Rigidbody2D Rigid;
    private void OnEnable()
    {
        GameRunSO.PlayerTouchAutoGetPropAction += GoPlayer;
    }
    private void OnDisable()
    {
        GameRunSO.PlayerTouchAutoGetPropAction -= GoPlayer;
    }
    protected void Start()
    {
        StartCoroutine(First());
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            Get();
            Destroy(this.gameObject);
        }
    }
    protected virtual void Get() { }
    protected void GoPlayer(Transform t)
    {
        Target = t;
        StartCoroutine(GoPlayerIEnum());
    }
    IEnumerator GoPlayerIEnum()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime);
            yield return 0;
        }
    }
    IEnumerator First()
    {
        Rigid = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 36) * 10);
        Rigid.AddForce(transform.right * Force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.identity;
        Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        while (true)
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
            yield return 0;
        }
    }
}
