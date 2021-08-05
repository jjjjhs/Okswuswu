using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryZone : MonoBehaviour
{
    public float hp;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Bullet") || other.gameObject.tag == ("Obstacle") || other.gameObject.tag == ("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}

