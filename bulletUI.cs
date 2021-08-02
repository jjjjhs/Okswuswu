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

    //���� �Ѿ�
    //���� �Ѿ� ���

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
        //���� �Ѿ� UI

        //ui ����
        CurrentBulletUI.text = "���� �Ѿ� : " + CurrentBullet;

        //�ִ� �Ѿ� UI

        //���������� �ִ� �Ѿ� ����

        if (enemyFactory.CountDiedButt > PlayerMove.stage1clear && enemyFactory.CountDiedMayo <= PlayerMove.stage2clear)
        {
            poolSize = stage2PoolSize;
            MaxBullet = poolSize;
            //���� �� ���� �Ѿ� ���� = �ִ� �Ѿ� ����
            CurrentBullet = MaxBullet;
        }
        else if (enemyFactory.CountDiedButt > PlayerMove.stage1clear && enemyFactory.CountDiedMayo > PlayerMove.stage2clear)
        {
            poolSize = stage3PoolSize;
            MaxBullet = poolSize;
            //���� �� ���� �Ѿ� ���� = �ִ� �Ѿ� ����
            CurrentBullet = MaxBullet;
        }


        //�ִ� �Ѿ� ������ ǥ���Ѵ� (������ �ʿ� X) 
        MaxBulletUI.text = "�ִ� �Ѿ� : " + MaxBullet;

    }
}
