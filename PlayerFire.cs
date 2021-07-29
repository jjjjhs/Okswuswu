using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // ��Ŭ�� �� �� ��������(�Ѿ�) �߻�
    // ��Ŭ�� �� �� �������� ȸ����(�ñر�)


    //�������� ������Ʈ
    public GameObject earFactory;

    //�߻� �� ��ġ
    public Transform firePosition;

    //�߻� �� ��
    public float throwPower = 10.0f;

    //�Ѿ� ����Ʈ ���� ������Ʈ
    public GameObject earEffect;


    //�Ѿ� ���ݷ�
    public int attackPower = 2;

    //��ƼŬ �ý��� ���� ������Ʈ
    ParticleSystem ps;

    //�ִϸ����� ������Ʈ
    Animator anim;




    //�ñر� ������Ʈ
    public GameObject ultimateSkill;

    //�Ҵ�� ���� ��
    public int enemyKill = 10;

    //���� ���� ���� ��
    int enemyCount = 0;

    //�÷��̾� ��ġ
    public GameObject target; 

    

        void Start()
    {
        //�ʱ���� �Ϲ� ���
        //gMode = GameMode.Normal;
    }



    // Update is called once per frame
    void Update()
    {
        //���콺 ��Ŭ��
        if (Input.GetMouseButtonDown(0))
        {
            //1. ���� ����
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            //2. ���̿� �ε��� ����� ���� ������ ����
            RaycastHit hitInfo = new RaycastHit();

            //3. ���̸� �߻��ؼ� �ε��� ����� �ִٸ�
            if (Physics.Raycast(ray, out hitInfo))
            {
                //���� �ε��� ����� ���̾ enemy���
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("enemy"))
                {
                   // enemyFSM eFSM = hitInfo.transform.GetComponent<enemyFSM>();
                   // eFSM.hitEnemy(attackPower);
                    enemyCount++;
                }
            }


            //�ε��� ��ġ�� �Ѿ� ����Ʈ ��ġ��Ŵ
            earEffect.transform.position = hitInfo.point;

            //�Ѿ� ����Ʈ ������ �΋H�� ������Ʈ�� ��������� ��ġ��Ŵ
            earEffect.transform.forward = hitInfo.normal;

            //�Ѿ� ����Ʈ �÷�����
            ps.Play();
        }

        //���� �Ҵ緮��ŭ ���� ���¿���
        //���콺 ��Ŭ��
        if(Input.GetMouseButtonDown(1)&&(enemyKill <= enemyCount))
        {
            shoot();

        }
    }




    public void shoot()
    {
        GameObject bulletPackage = Instantiate(earFactory); //��ȯ���� ���ӿ�����Ʈ

        bulletPackage.transform.position = firePosition.position; //�Ѿ� ������ ���� ���� �ѱ� ��ġ
        bulletPackage.transform.up = (target.transform.position - firePosition.position).normalized; //�� ������ Ÿ���� ���� ����(�÷��̾ ���� �߻��ϱ� ���� �ڵ�)

        Transform[] childs = bulletPackage.GetComponentsInChildren<Transform>(); //�Ѿ� �������� �ڽ� 5���� ������

        for (int i = 0; i < childs.Length; i++) //�� �Ѿ��� �θ�-�ڽ� ���踦 ������
        {
            childs[i].parent = null;
        }
        Destroy(bulletPackage); //�Ѿ��� ���� �ִ� �� ������Ʈ�� ����
    }




   
}
