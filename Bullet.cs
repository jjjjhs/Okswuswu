using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�̵� �ӵ�
    public float speed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        //�̵�
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
//������ �Ѿ�
//��Ŭ���� �Ѿ� ������ <- 3���� ����