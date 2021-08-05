using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class stopPotion : MonoBehaviour
{
    public float currentTime;
    public float potionTime;
    Vector3 dir;

    public float potionSpeed = 1.0f;
    Transform Player;

    enum State
    {
        Idle
    };

    State state = State.Idle;
    void Start()
    {
        dir = Vector3.left;

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (transform.position.x - Player.position.x > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.5f);
        }

        if (state == State.Idle)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.5f);

            butter.butterSpeed = 2f;
            mayonnaise.mayoSpeed = 3f;
            cheese.cheeseSpeed = 4f;

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

