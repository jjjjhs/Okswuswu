using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleFactory : MonoBehaviour
{

    public GameObject obstacleSpawn;
    public float createTime = 2;
    public float currentTime;

    void Start()
    {


    }

    void Update()
    {
        int randValue = Random.Range(0, 10);
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if(randValue < 3)
            {
                GameObject obstacle = Instantiate(obstacleSpawn);
                obstacle.transform.position = this.gameObject.transform.position;
            }
            currentTime = 0;
        }
    }
}