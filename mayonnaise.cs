using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaise : MonoBehaviour
{
    //���� 4�� = ������Ʈ �迭 4��
    public GameObject[] potions = new GameObject[4];

    //������� �ӵ�
    static public float mayoSpeed = 3f;

    //������� ü��
    public int HpMayo = 2;

    Vector3 dir;

    //������ ȿ��
    GameObject explosion;
    public GameObject explosionFactory;

    //���� ����
    GameObject pot;
    Transform Player;


    void Start()
    {
            //->������ �Ʒ���
            dir = Vector3.left;

        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position += dir * mayoSpeed * Time.deltaTime;

        if (HpMayo == 0)
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

