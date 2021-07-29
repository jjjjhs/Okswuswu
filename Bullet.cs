using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public static int poolSize;
    public static int stagePoolSize = 50;
    public static int stagePoolSize1 = 150;
    public static int stagePoolSize2 = 250;
    GameObject[] bulletObjectPool;
    GameObject other;
   

    public float speed;    //이동 속도
    void Start()
    {
        
    }

    void Update()
    {
        //이동
        transform.position += Vector3.right * speed * Time.deltaTime;

        if(other.gameObject.name.Contains("butter"))
        {
            poolSize = stagePoolSize;
        }
        else if (other.gameObject.name.Contains("mayonaise"))
        {
            poolSize = stagePoolSize1;
        }
        else if (other.gameObject.name.Contains("cheese"))
        {
            poolSize = stagePoolSize2;
        }
    }
}