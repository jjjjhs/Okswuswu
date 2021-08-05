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
    enum StageChange
    {
        stage1,
        stage2,
        stage3
    }

    StageChange stagechange;

    void Start()
    {
        stagechange = StageChange.stage1;
    }

    void Update()
    {
        switch (stagechange)
        {
            case StageChange.stage1:
                stage1();
                break;
            case StageChange.stage2:
                stage2();
                break;
            case StageChange.stage3:
                stage3();
                break;
        }


        CurrentBulletUI.text = "현재 총알 : " + CurrentBullet;

        //최대 총알 개수를 표시한다 (증가할 필요 X) 
        MaxBulletUI.text = "최대 총알 : " + MaxBullet;

    }
    void stage1()
    {
        poolSize = stage1PoolSize;
        MaxBullet = poolSize;
        CurrentBullet = MaxBullet;

        if (butterFactory.CountDiedButt > PlayerMove.stage1clear && mayonnaiseFactory.CountDiedMayo <= PlayerMove.stage2clear)
        {
            stagechange = StageChange.stage2;
        }

    }

    void stage2()
    {
        poolSize = stage2PoolSize;
        MaxBullet = poolSize;
        CurrentBullet = MaxBullet;

        if (butterFactory.CountDiedButt > PlayerMove.stage1clear && mayonnaiseFactory.CountDiedMayo > PlayerMove.stage2clear)
        {
            stagechange = StageChange.stage3;
        }
    }

    void stage3()
    {
        poolSize = stage3PoolSize;
        MaxBullet = poolSize;
        CurrentBullet = MaxBullet;
    }

}
