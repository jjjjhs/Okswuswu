using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butter : MonoBehaviour
{
    public float cheeseSpeed = 7;
    public int HpChee = 7;

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
        transform.position += dir * cheeseSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == bullet)
        {
            HpChee--;
        }
        if(HpChee==0)
        {
            Destroy(gameObject);
        }
    }
}