using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerFire : MonoBehaviour
{

    public GameObject bulletFactory;
    public GameObject firePosition;

    public static int poolSize; //총알 갯수
    //총알갯수 스테이지별로 다르게

    GameObject[] bulletObjectPool;

    public GameObject target; //플레이어 위치
    public Transform firePosition_Enemy; // 총구위치
    public GameObject bulletPackageFactory; // 총알5 공장

    void Start()
    {
        bulletObjectPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool[i] = bullet;
            bullet.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }

        }

        if (Input.GetKeyDown("r"))
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    shoot();
                    break;
                }
            }
        }

    }

    public void shoot()
    {
        GameObject bulletPackage = Instantiate(bulletPackageFactory); //반환값은 게임오브젝트

        bulletPackage.transform.position = firePosition_Enemy.position; //총알 묶음이 나갈 곳은 총구 위치
        bulletPackage.transform.up = (target.transform.position - firePosition_Enemy.position).normalized; //앞 방향을 타겟을 향해 조정

        Transform[] childs = bulletPackage.GetComponentsInChildren<Transform>(); //총알 묶음에서 자식 5개를 가져옴

        for (int i = 0; i < childs.Length; i++) //각 총알의 부모-자식 관계를 끊어줌
        {
            childs[i].parent = null;
        }
        Destroy(bulletPackage); //총알을 묶고 있던 빈 오브젝트를 삭제
    }
}
