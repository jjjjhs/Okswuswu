using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //이동 속도
    public float speed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        //이동
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
//옥수수 총알
//좌클릭시 총알 나가게 <- 3주차 참고