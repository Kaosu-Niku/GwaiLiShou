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
        //? 敵人要做的事
        yield break;
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
        GetPlayer = GameRunSO.Player.GetComponent<Player>();
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameRunSO.PlayerMissTrigger();
    }

}
