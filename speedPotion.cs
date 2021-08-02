using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class speedPotion : MonoBehaviour
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
                PlayerMove.moveSpeed++;
                Background.m_scrollSpeed--;
                currentTime = 0f;
                Destroy(gameObject);
            }
        }
    }
}
