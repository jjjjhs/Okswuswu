using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheese : MonoBehaviour
{
    //���� 4�� = ������Ʈ �迭 4��
    public GameObject[] potions = new GameObject[4];
    GameObject potion;

    public float potionSpeed = 3.0f;

    //ġ�� �ӵ�
    static public float cheeseSpeed = 4f;

    //ġ�� ü��
    public int HpChee = 3;

    Vector3 dir;

    //������ ȿ��
    GameObject explosion;
    public GameObject explosionFactory;

    //���� ����
    GameObject pot;
    Transform Player;

    //��ֹ� �浹 �� �������� �ʵ���
    GameObject obstacle;

    void Start()
    {
        //->������ �Ʒ���
        dir = Vector3.left;

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position += dir * cheeseSpeed * Time.deltaTime;

        if (HpChee == 0)
        {
            //���� �׾��� �� ���� ����
            int maxpotion = 1;
            int rand = Random.Range(0, 4);
            int randValue = Random.Range(0, 9);
            if (randValue < 2)
            {
                for (int i = 0; i < maxpotion; i++)
                {
                    pot = Instantiate(potions[rand]); // ���� ����
                    if (pot.transform.position.x - Player.position.x > 1)
                    {
                        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 3);
                    }
                    break;
                }
            }

            //������ ȿ��
            explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
            cheesefactory.CountDiedChee++;
        }

    }


    //���� �ε������� hp�� �پ��
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



