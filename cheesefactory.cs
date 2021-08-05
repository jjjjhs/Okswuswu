using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheesefactory : MonoBehaviour
{
    public float createTime = 2;
    float currentTime;

    public GameObject cheeFactory;

    public float minTime = 1;
    public float maxTime = 5;

    public static int CountDiedChee = 0;

    public int stage1clear = 10;
    public int stage2clear = 30;
    public int stage3clear = 50;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject enemy = Instantiate(cheeFactory);

            enemy.transform.position = this.gameObject.transform.position;

            currentTime = 0;

            createTime = Random.Range(minTime, maxTime);

        }
    }
}
