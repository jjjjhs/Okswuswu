using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed;
    private GameObject Obstacle;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("bullet"))
        {
            Obstacle.SetActive(false);
        }
        else if (other.gameObject.name.Contains("enemy"))
        {
            Obstacle.SetActive(false);
        }
    }
}
