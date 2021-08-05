using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stage3pool : MonoBehaviour
{
    public static int poolSize;
    public static int stage3PoolSize = 90;

    GameObject[] bulletObjectPool;
    GameObject other;

    public Text CurrentBulletUI;
    [HideInInspector]
    static public int CurrentBullet = -1;

    public Text MaxBulletUI;
    [HideInInspector]
    public int MaxBullet;

    void Start()
    {
        poolSize = stage3PoolSize;
        MaxBullet = poolSize;
        CurrentBullet = MaxBullet;
    }

    void Update()
    {
        CurrentBulletUI.text = "ÇöÀç ÃÑ¾Ë : " + CurrentBullet;

        MaxBulletUI.text = "ÃÖ´ë ÃÑ¾Ë : " + MaxBullet;
    }
}
