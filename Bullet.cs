using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Bullet : MonoBehaviour
{

    public float speed;    //이동 속도
    void Start()
    {
    }

    void Update()
    {
        //이동
        transform.position += Vector3.right * speed * Time.deltaTime;

      
    }
}