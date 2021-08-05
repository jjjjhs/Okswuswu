using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheese : MonoBehaviour
{
    //포션 4개 = 오브젝트 배열 4개
    public GameObject[] potions = new GameObject[4];
    GameObject potion;

    public float potionSpeed = 3.0f;

    //치즈 속도
    static public float cheeseSpeed = 4f;

    //치즈 체력
    public int HpChee = 3;

    Vector3 dir;

    //터지는 효과
    GameObject explosion;
    public GameObject explosionFactory;

    //포션 생성
    GameObject pot;
    Transform Player;

    //장애물 충돌 시 반응하지 않도록
    GameObject obstacle;

    void Start()
    {
        //->방향을 아래로
        dir = Vector3.left;

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position += dir * cheeseSpeed * Time.deltaTime;

        if (HpChee == 0)
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

            //터지는 효과
            explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            cheesefactory.CountDiedChee++;
        }

    }


    //적과 부딪혔을때 hp가 줄어듬
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HpChee--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == ("obstacle"))
        {
            obstacle.SetActive(false);
        }
    }
}



