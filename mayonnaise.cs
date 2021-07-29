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
