using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPotion : MonoBehaviour
{
    public float currentTime;
    public float potionTime;
    Vector3 dir;

    Transform Player;

    enum State
    {
        Idle,
        bumpedPotion,
        whilePotion,
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

        switch (state)
        {
            case State.Idle:
                if (state == State.Idle)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.1f);
                    state = State.bumpedPotion;

                }
                break;

            case State.bumpedPotion:
                if (state == State.bumpedPotion)
                {
                    state = State.whilePotion;
                }
                break;

            case State.whilePotion:
                if (state == State.whilePotion)
                {
                    if (currentTime < potionTime)
                    {
                        PlayerMove.hp++;
                        currentTime = 0f;
                        state = State.Idle;
                    }
                }
                break;
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
