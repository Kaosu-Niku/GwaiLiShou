using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPoolDataSO", menuName = "ScriptObject/EnemyPoolDataSO")]
public class EnemyPoolDataSO : ScriptableObject
{
    [System.Serializable]
    public class EnemyData
    {
        public Enemy Who;
        public float StartTime;
        public Vector2 StartPos;
    }
    [SerializeField] List<EnemyData> _AllEnemyData = new List<EnemyData>();
    public List<EnemyData> AllEnemyData { get => _AllEnemyData; }
}
