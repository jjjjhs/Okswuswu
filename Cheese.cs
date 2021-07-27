using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;

    public GameObject explosionFactory;

    void Start()
    {
        int randValue = Random.Range(0, 10);

        if (randValue < 3)
        {
            //변경해야할 사항
            GameObject target = GameObject.Find("player"); //player OR corn
                
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            //변경해야할 사항
            dir = Vector3.left; //방향 변경
        }
    }
void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("bullet"))
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            //Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }
}