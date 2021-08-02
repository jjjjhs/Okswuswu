using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPotion : MonoBehaviour
{
    public float currentTime;
    public float potionTime;

    void Start()
    {

    }

    void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Player"))
        {
            if (currentTime < potionTime)
            {
                PlayerMove.hp++;
                currentTime = 0f;
                Destroy(gameObject);
            }
        }
    }
}

