using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : MonoBehaviour
{
    [System.Serializable]
    public class Effect
    {
        public string tag;
        public EffectSystem effect;
        public int count;
    }
    [SerializeField] List<Effect> SetAllBullet = new List<Effect>();
    Dictionary<string, Queue<EffectSystem>> AllEffectPool = new Dictionary<string, Queue<EffectSystem>>();
    private void Awake()
    {
        for (int x = 0; x < SetAllBullet.Count; x++)
        {
            Queue<EffectSystem> q = new Queue<EffectSystem>();
            for (int y = 0; y < SetAllBullet[x].count; y++)
            {
                EffectSystem b = Instantiate(SetAllBullet[x].effect);
                q.Enqueue(b);
                b.MyPool = this;
                b.MyTag = SetAllBullet[x].tag;
                b.gameObject.SetActive(false);
            }
            AllEffectPool.Add(SetAllBullet[x].tag, q);
        }
    }
    public EffectSystem OutEffect(string tag, Vector3 pos, Quaternion rot)
    {
        if (AllEffectPool.ContainsKey(tag) == true)
        {
            if (AllEffectPool[tag].Count > 0)
            {
                EffectSystem b = AllEffectPool[tag].Dequeue();
                b.gameObject.SetActive(true);
                b.transform.position = pos;
                b.transform.rotation = rot;
                return b;
            }
            else
            {
                for (int x = 0; x < SetAllBullet.Count; x++)
                {
                    if (SetAllBullet[x].tag == tag)
                    {
                        EffectSystem b = Instantiate(SetAllBullet[x].effect);
                        b.MyPool = this;
                        b.MyTag = SetAllBullet[x].tag;
                        b.transform.position = pos;
                        b.transform.rotation = rot;
                        return b;
                    }
                }
                Debug.Log("不可能找不到");
                return null;
            }
        }
        else
        {
            Debug.Log("找不到");
            return null;
        }
    }
    public void InEffect(string tag, EffectSystem b)
    {
        if (AllEffectPool.ContainsKey(tag) == true)
        {
            AllEffectPool[tag].Enqueue(b);
        }
    }


}
