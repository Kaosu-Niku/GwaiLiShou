using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [System.Serializable]
    public class Bullet
    {
        public string tag;//! 遵照格式 關卡-敵人編號-第幾種彈幕 ex: S100802 => 第一關的編號8敵人的第二種彈幕
        public BulletSystem bullet;
        public int count;
    }
    [SerializeField] List<Bullet> SetAllBullet = new List<Bullet>();
    Dictionary<string, Queue<BulletSystem>> AllBulletPool = new Dictionary<string, Queue<BulletSystem>>();
    private void Awake()
    {
        for (int x = 0; x < SetAllBullet.Count; x++)
        {
            Queue<BulletSystem> q = new Queue<BulletSystem>();
            for (int y = 0; y < SetAllBullet[x].count; y++)
            {
                BulletSystem b = Instantiate(SetAllBullet[x].bullet, transform);
                q.Enqueue(b);
                b.MyPool = this;
                b.MyTag = SetAllBullet[x].tag;
                b.gameObject.SetActive(false);
            }
            AllBulletPool.Add(SetAllBullet[x].tag, q);
        }
    }
    public BulletSystem OutBullet(string tag, Vector3 pos, Quaternion rot)
    {
        if (AllBulletPool.ContainsKey(tag) == true)
        {
            if (AllBulletPool[tag].Count > 0)
            {
                BulletSystem b = AllBulletPool[tag].Dequeue();
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
                        BulletSystem b = Instantiate(SetAllBullet[x].bullet, transform);
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
    public void InBullet(string tag, BulletSystem b)
    {
        if (AllBulletPool.ContainsKey(tag) == true)
        {
            AllBulletPool[tag].Enqueue(b); Debug.Log(AllBulletPool[tag].Count);
        }
    }


}
