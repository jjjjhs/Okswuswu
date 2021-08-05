using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaiseFactory : MonoBehaviour
{
    public float createTime = 2;
    float currentTime;

    //총알
    public GameObject mayoFactory;

    //스테이지 넘어가기 위해 죽은 적의 수 세기
    public static int CountDiedMayo = 0;

    //스테이지 넘어갈기 위한 적의 수
    public int stage1clear = 10;
    public int stage2clear = 30;

    public float minTime = 1;
    public float maxTime = 5;


    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {

            GameObject enemy = Instantiate(mayoFactory);

            enemy.transform.position = this.gameObject.transform.position;

            currentTime = 0;

            createTime = Random.Range(minTime, maxTime);
        }
    }
}
