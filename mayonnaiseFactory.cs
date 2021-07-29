using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaiseFactory : MonoBehaviour
{
    public float createTime = 2;
    float currentTime;

    public GameObject mayoFactory;
    public GameObject butterFactory;
    public GameObject cheeseFactory;

    int CountDiedMayo = 0;
    int CountDiedButt = 0;
    int CountDiedChee = 0;

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
        if(GameObject.Find("mayonnaise").GetComponent<mayonnaise>().HpMayo)
        {
            CountDiedMayo++;
        }
        if (GameObject.Find("cheese").GetComponent<cheese>().HpChee)
        {
            CountDiedChee++;
        }
        if (GameObject.Find("butter").GetComponent<butter>().HpButt)
        {
            CountDiedButt++;
        }


        currentTime += Time.deltaTime;

        if (CountDiedButt <= 10)
        {
            if (currentTime > createTime)
            {
                GameObject enemy = Instantiate(mayoFactory);

                enemy.transform.position = this.gameObject.transform.position;

                currentTime = 0;

                createTime = Random.Range(minTime, maxTime);
            }
        }

        if (CountDiedButt > 10 && CountDiedMayo <= 30)
        {
            if (currentTime > createTime)
            {
                GameObject enemy = Instantiate(butterFactory);

                enemy.transform.position = this.gameObject.transform.position;

                currentTime = 0;

                createTime = Random.Range(minTime, maxTime);
            }
        }

        if (CountDiedButt > 10 && CountDiedMayo > 30 && CountDiedChee <= 70)
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
