using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerFire : MonoBehaviour
{

    public GameObject bulletFactory;
    public GameObject firePosition;

    public static int poolSize; //�Ѿ� ����
    //�Ѿ˰��� ������������ �ٸ���

    GameObject[] bulletObjectPool;

    public GameObject target; //�÷��̾� ��ġ
    public Transform firePosition_Enemy; // �ѱ���ġ
    public GameObject bulletPackageFactory; // �Ѿ�5 ����

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
        GameObject bulletPackage = Instantiate(bulletPackageFactory); //��ȯ���� ���ӿ�����Ʈ

        bulletPackage.transform.position = firePosition_Enemy.position; //�Ѿ� ������ ���� ���� �ѱ� ��ġ
        bulletPackage.transform.up = (target.transform.position - firePosition_Enemy.position).normalized; //�� ������ Ÿ���� ���� ����

        Transform[] childs = bulletPackage.GetComponentsInChildren<Transform>(); //�Ѿ� �������� �ڽ� 5���� ������

        for (int i = 0; i < childs.Length; i++) //�� �Ѿ��� �θ�-�ڽ� ���踦 ������
        {
            childs[i].parent = null;
        }
        Destroy(bulletPackage); //�Ѿ��� ���� �ִ� �� ������Ʈ�� ����
    }
}
