using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class speedPotion : MonoBehaviour
{
    public float currentTime;
    public float potionTime;

    private GameObject[] potions = new GameObject[4];
    private GameObject potion;

    Vector3 dir;
    public float potionSpeed = 4.0f;

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


