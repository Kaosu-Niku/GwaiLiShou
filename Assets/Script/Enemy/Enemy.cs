using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Hp;
    [SerializeField] Vector3 FirstPos;
    [SerializeField] protected float Speed;
    [SerializeField] float DestroyTime;
    [SerializeField] int Score;
    protected Player GetPlayer;//* 控制玩家

    protected virtual IEnumerator StartAction()//? 敵人自定義行動
    {
        Vector3 Left = new Vector3(-3.5f, transform.position.y, 0);
        Vector3 Right = new Vector3(3.5f, transform.position.y, 0);
        //? 敵人要做的事
        while (true)
        {
            while (transform.position.x > -3)
            {
                transform.position = Vector3.Lerp(transform.position, Left, Time.deltaTime);
                yield return 0;
            }
            while (transform.position.x < 3)
            {
                transform.position = Vector3.Lerp(transform.position, Right, Time.deltaTime);
                yield return 0;
            }
            yield return 0;
        }
    }
    public void Hurt(float damage)
    {
        Hp -= damage; Debug.Log(Hp);
        {

        }
        if (Hp < 0)
            Death();
    }
    protected void Death()
    {
        GameDataSO.Score += Score;
        Destroy(this.gameObject);
    }
    private void OnEnable()
    {
        GameRunSO.AllEnemy.Add(this.gameObject);
    }
    private void OnDisable()
    {
        GameRunSO.AllEnemy.Remove(this.gameObject);
    }
    private void Start()
    {
        transform.position = FirstPos;
        Invoke("Death", DestroyTime);
        StartCoroutine(StartAction());
        GetPlayer = GameRunSO.Player;
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameRunSO.PlayerMissTrigger();
    }

}
