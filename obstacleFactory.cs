using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleFactory : MonoBehaviour
{

    public GameObject obstacleSpawn;
    public float createTime = 2.5f;
    public float currentTime;


    void Update()
    {
        int randValue = Random.Range(0, 10);
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if (randValue < 2)
            {
                GameObject obstacle = Instantiate(obstacleSpawn);
                obstacle.transform.position = this.gameObject.transform.position;
            }
            currentTime = 0;
        }
    }
}