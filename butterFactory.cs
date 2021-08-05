using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterFactory : MonoBehaviour
{
    public float createTime = 2;
    float currentTime;
    public GameObject buttFactory;

    public float minTime = 1;
    public float maxTime = 5;

    public static int CountDiedButt = 0;
    public int stage1clear = 10;

    void Start()
    {
        //태어날때 적 생성시간을 설정한다
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if (CountDiedButt <= stage1clear)
            {

                GameObject enemy = Instantiate(buttFactory);

                enemy.transform.position = this.gameObject.transform.position;

                currentTime = 0;

                createTime = Random.Range(minTime, maxTime);
            }
        }
    }
}
