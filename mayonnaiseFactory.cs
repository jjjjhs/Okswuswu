using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaiseFactory : MonoBehaviour
{
    public float createTime = 2;
    float currentTime;

    //총알
    public GameObject mayoFactory;
    public GameObject butterFactory;
    public GameObject cheeseFactory;

    //스테이지 넘어가기 위해 죽은 적의 수 세기
    public static int CountDiedMayo = 0;
    public static  int CountDiedButt = 0;
    public static int CountDiedChee = 0;

    public int stage1clear = 10;
    public int stage2clear = 30;
    public int stage3clear = 50;

    public int HpButt = 3;
    public int HpMayo = 5;
    public int HpChee = 7;

    public float minTime = 1;
    public float maxTime = 5;


    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (CountDiedButt <= stage1clear)
        {
            if (currentTime > createTime)
            {
                GameObject enemy = Instantiate(butterFactory);

                enemy.transform.position = this.gameObject.transform.position;

                currentTime = 0;

                createTime = Random.Range(minTime, maxTime);
            }
        }

        if (CountDiedButt > stage1clear && CountDiedMayo <= stage2clear)
        {
            if (currentTime > createTime)
            {
                GameObject enemy = Instantiate(mayoFactory);

                enemy.transform.position = this.gameObject.transform.position;

                currentTime = 0;

                createTime = Random.Range(minTime, maxTime);
            }
        }

        if (CountDiedButt > stage1clear && CountDiedMayo > stage2clear && CountDiedChee <= stage3clear)
        {
            if (currentTime > createTime)
            {
                GameObject enemy = Instantiate(cheeseFactory);

                enemy.transform.position = this.gameObject.transform.position;

                currentTime = 0;

                createTime = Random.Range(minTime, maxTime);
            }
        }
    }
}
