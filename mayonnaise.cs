using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaise : MonoBehaviour
{
    //포션 4개 = 오브젝트 배열 4개
    public GameObject[] potions = new GameObject[4];

    //마요네즈 속도
    static public float mayoSpeed = 3f;

    //마요네즈 체력
    public int HpMayo = 2;

    Vector3 dir;

    //터지는 효과
    GameObject explosion;
    public GameObject explosionFactory;

    //포션 생성
    GameObject pot;
    Transform Player;


    void Start()
    {
            //->방향을 아래로
            dir = Vector3.left;

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position += dir * mayoSpeed * Time.deltaTime;

        if (HpMayo == 0)
        {
            //적이 죽었을 때 포션 생성
            int maxpotion = 1;
            int rand = Random.Range(0, 4);
            int randValue = Random.Range(0, 9);
            if (randValue < 2)
            {
                for (int i = 0; i < maxpotion; i++)
                {
                    pot = Instantiate(potions[rand]); // 랜덤 생성
                    if (pot.transform.position.x - Player.position.x > 1)
                    {
                        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 3);
                    }
                    break;
                }
            }
            explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            mayonnaiseFactory.CountDiedMayo++;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            HpMayo--;
            Destroy(collision.gameObject);
        }

    }

}

