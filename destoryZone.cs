using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryZone : MonoBehaviour
{
    public float hp;

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("bullet"))
        {
            Destroy(other.gameObject);
        }

    }
}

