using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaise : MonoBehaviour
{
    public float mayoSpeed = 5;
    public int HpMayo = 5;

    public int CountDiedMayo = 0;

    Vector3 dir;

    void Start()
    {
        int randValue = Random.Range(0, 10);
        //���� 3 �̸��̸�
        if (randValue < 3)
        {
            //->������ �÷��̾� ������
            //�ʿ��� ���� ->player Gameobject�� ��ġ�� �ʿ��ϴ�.
            GameObject target = GameObject.Find("player");

            // ������ ���Ѵ�, target<-me
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        //�׷��� ������
        else
        {
            //->������ �Ʒ���
            dir = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * mayoSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == bullet)
        {
            HpMayo--;
        }
        if (HpMayo == 0)
        {
            Destroy(gameObject);
            CountDiedMayo++;
        }
    }
}
