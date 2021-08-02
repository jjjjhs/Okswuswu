using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class stopPotion : MonoBehaviour
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

                cheese.cheeseSpeed = 0;
                mayonnaise.mayoSpeed = 0;
                butter.butterSpeed = 0;
                currentTime = 0f;
                Destroy(gameObject);
            }
        }
    }
}
