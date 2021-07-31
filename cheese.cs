using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butter : MonoBehaviour
{
    public float cheeseSpeed = 7;
    public int HpChee = 7;

    Vector3 dir;

    //중력변수
    public float gravity = -20.0f;

    //수직속도변수
    float yVelocity = 0;

    void Start()
    {
        int randValue = Random.Range(0, 10);
        //만약 3 미만이면
        if (randValue < 3)
        {
            //->방향을 플레이어 쪽으로
            //필요한 정보 ->player Gameobject의 위치가 필요하다.
            GameObject target = GameObject.Find("player");

            // 방향을 구한다, target<-me
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        //그렇지 않으면
        else
        {
            //->방향을 아래로
            dir = Vector3.right;
        }
    }

    void Update()
    {
        transform.position += dir * cheeseSpeed * Time.deltaTime;

        //캐릭터에 중력 작용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            HpChee--;
        }
        if(HpChee==0)
        {
            Destroy(gameObject);
            mayonnaiseFactory.CountDiedChee++;
        }
    }
}