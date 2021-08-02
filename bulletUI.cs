using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletUI : MonoBehaviour
{
    public static int poolSize;
    public static int stage1PoolSize = 50;
    public static int stage2PoolSize = 150;
    public static int stage3PoolSize = 250;
    GameObject[] bulletObjectPool;
    GameObject other;

    //현재 총알
    //현재 총알 기억

    public Text CurrentBulletUI;
    [HideInInspector]
    public int CurrentBullet;

    public Text MaxBulletUI;
    [HideInInspector]
    public int MaxBullet;

    void Start()
    {
        poolSize = stage1PoolSize;
        MaxBullet = poolSize;
        CurrentBullet = MaxBullet;
    }

    void Update()
    {
        //현재 총알 UI

        //ui 적용
        CurrentBulletUI.text = "현재 총알 : " + CurrentBullet;

        //최대 총알 UI

        //스테이지별 최대 총알 개수

        if (enemyFactory.CountDiedButt > PlayerMove.stage1clear && enemyFactory.CountDiedMayo <= PlayerMove.stage2clear)
        {
            poolSize = stage2PoolSize;
            MaxBullet = poolSize;
            //시작 시 현재 총알 개수 = 최대 총알 개수
            CurrentBullet = MaxBullet;
        }
        else if (enemyFactory.CountDiedButt > PlayerMove.stage1clear && enemyFactory.CountDiedMayo > PlayerMove.stage2clear)
        {
            poolSize = stage3PoolSize;
            MaxBullet = poolSize;
            //시작 시 현재 총알 개수 = 최대 총알 개수
            CurrentBullet = MaxBullet;
        }


        //최대 총알 개수를 표시한다 (증가할 필요 X) 
        MaxBulletUI.text = "최대 총알 : " + MaxBullet;

    }
}
