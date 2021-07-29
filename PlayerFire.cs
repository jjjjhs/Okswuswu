using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 좌클릭 할 때 옥수수알(총알) 발사
    // 우클릭 할 때 옥수수알 회오리(궁극기)


    //옥수수알 오브젝트
    public GameObject earFactory;

    //발사 할 위치
    public Transform firePosition;

    //발사 할 힘
    public float throwPower = 10.0f;

    //총알 이펙트 게임 오브젝트
    public GameObject earEffect;


    //총알 공격력
    public int attackPower = 2;

    //파티클 시스템 게임 오브젝트
    ParticleSystem ps;

    //애니메이터 컴포넌트
    Animator anim;




    //궁극기 오브젝트
    public GameObject ultimateSkill;

    //할당된 적의 수
    public int enemyKill = 10;

    //현재 죽인 적의 수
    int enemyCount = 0;

    //플레이어 위치
    public GameObject target; 

    

        void Start()
    {
        //초기모드는 일반 모드
        //gMode = GameMode.Normal;
    }



    // Update is called once per frame
    void Update()
    {
        //마우스 좌클릭
        if (Input.GetMouseButtonDown(0))
        {
            //1. 레이 생성
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            //2. 레이에 부디진 대상의 정보 저장할 변수
            RaycastHit hitInfo = new RaycastHit();

            //3. 레이를 발사해서 부딪힌 대상이 있다면
            if (Physics.Raycast(ray, out hitInfo))
            {
                //만약 부딪힌 대상의 레이어가 enemy라면
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("enemy"))
                {
                   // enemyFSM eFSM = hitInfo.transform.GetComponent<enemyFSM>();
                   // eFSM.hitEnemy(attackPower);
                    enemyCount++;
                }
            }


            //부딪힌 위치에 총알 이펙트 위치시킴
            earEffect.transform.position = hitInfo.point;

            //총알 이펙트 방향을 부딫힌 오브젝트와 수직방향과 일치시킴
            earEffect.transform.forward = hitInfo.normal;

            //총알 이펙트 플레이함
            ps.Play();
        }

        //적을 할당량만큼 죽인 상태에서
        //마우스 우클릭
        if(Input.GetMouseButtonDown(1)&&(enemyKill <= enemyCount))
        {
            shoot();

        }
    }




    public void shoot()
    {
        GameObject bulletPackage = Instantiate(earFactory); //반환값은 게임오브젝트

        bulletPackage.transform.position = firePosition.position; //총알 묶음이 나갈 곳은 총구 위치
        bulletPackage.transform.up = (target.transform.position - firePosition.position).normalized; //앞 방향을 타겟을 향해 조정(플레이어를 보고 발사하기 위한 코드)

        Transform[] childs = bulletPackage.GetComponentsInChildren<Transform>(); //총알 묶음에서 자식 5개를 가져옴

        for (int i = 0; i < childs.Length; i++) //각 총알의 부모-자식 관계를 끊어줌
        {
            childs[i].parent = null;
        }
        Destroy(bulletPackage); //총알을 묶고 있던 빈 오브젝트를 삭제
    }




   
}
