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
            //�����ؾ��� ����
            GameObject target = GameObject.Find("player"); //player OR corn
                
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            //�����ؾ��� ����
            dir = Vector3.left; //���� ����
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