using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Obstacle.SetActive(false);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Obstacle.SetActive(false);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Ending_bad_Popcorn");
        }
    }
}
