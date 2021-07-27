using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheeseFactory : MonoBehaviour
{
    public float createTime = 2;
    public float currentTime;
    public GameObject enemyFactory;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject Cheese = Instantiate(enemyFactory);
            Cheese.transform.position = this.gameObject.transform.position;

            currentTime = 0;
        }
    }
}
