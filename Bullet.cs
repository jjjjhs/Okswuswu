using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Bullet : MonoBehaviour
{

    public float speed;    //�̵� �ӵ�
    void Start()
    {
    }

    void Update()
    {
        //�̵�
        transform.position += Vector3.right * speed * Time.deltaTime;

      
    }
}