using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] float Hp;
    [SerializeField] protected float Speed;
    [SerializeField] int Score;
    [SerializeField] bool UseStop;//? 是否是能停止生成進度的敵人
    private Player _GetPlayer;
    protected Player GetPlayer { get => _GetPlayer; }
    protected abstract IEnumerator CustomAction();//? 敵人自定義行動
    protected IEnumerator StartAction()
    {
        if (UseStop == true)
            GameRunSO.StopEnemyPoolTrigger(true);
        yield return StartCoroutine(CustomAction());
        yield return 0;
        Clear();
    }
    protected virtual void Hurt(float damage)//? BOSS覆寫
    {
        Hp -= damage; Debug.Log(Hp);
        if (Hp < 0)
        {
            GameDataSO.Score += Score;
            Clear();
        }
    }
    public void CallHurt(float damage)
    {
        Hurt(damage);
    }
    protected virtual void Clear()//? BOSS覆寫
    {
        if (UseStop == true)
            GameRunSO.StopEnemyPoolTrigger(false);
        gameObject.SetActive(false);
    }
    protected void Awake()
    {
        _GetPlayer = GameRunSO.Player;
    }
    protected void OnEnable()
    {
        GameRunSO.AllEnemy.Add(this.gameObject);
    }
    protected void OnDisable()
    {
        GameRunSO.AllEnemy.Remove(this.gameObject);
    }
    private void Start()
    {
        StartCoroutine(StartAction());
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameRunSO.PlayerMissTrigger();
    }

}
