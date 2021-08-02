using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePotion : MonoBehaviour
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
        if(other.gameObject.name == ("Player"))
        {
            if(currentTime < potionTime)
            {
                PlayerFire1.attackPower++;
                currentTime = 0f;
                Destroy(gameObject);
            }
        }
    }
}
