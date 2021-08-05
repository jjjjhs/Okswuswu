using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class butter : MonoBehaviour
{
    //포션
    public GameObject[] potions = new GameObject[4];
    public GameObject potion;

    public GameObject explosionFactory;
    public static float butterSpeed = 2f;
    public int HpButt = 1;

    Vector3 dir;

    GameObject obstacle;
    GameObject explosion;

    Transform Player;
    GameObject pot;

    void Start()
    {
        //->방향
        dir = Vector3.left;

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (HpButt == 0)
        {
            //적이 죽었을 때 포션 생성
            int maxpotion = 1;
            int rand = Random.Range(0, 4);
            int randValue = Random.Range(0, 9);
            if (randValue < 1)
            {
                for (int i = 0; i < maxpotion; i++)
                {
                    pot = Instantiate(potions[rand]); // 랜덤 생성
                    break;
                }
            }

            explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            butterFactory.CountDiedButt++;
        }

        transform.position += dir * butterSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HpButt--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == ("obstacle"))
        {
            obstacle.SetActive(false);
        }
    }
}
