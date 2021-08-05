using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePotion : MonoBehaviour
{
    public float currentTime;
    public float potionTime;

    Vector3 dir;
    public float potionSpeed = 1.0f;

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
            //transform.Translate(new Vector2(-5, 0) * Time.deltaTime * potionSpeed);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.5f);
        }

        //제대로 작동안하는 스위치문
        switch (state)
        {
            case State.Idle:
                if (state == State.Idle)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.5f);
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
                        PlayerFire1.attackPower++;
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

    IEnumerator DamagePotion()
    {
        PlayerFire1.attackPower++;
        yield return new WaitForSeconds(2.0f);
        state = State.Idle;
    }
}
