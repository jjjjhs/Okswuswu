using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire1 : MonoBehaviour
{
    // 좌클릭 할 때 옥수수알(총알) 발사
    // 우클릭 할 때 옥수수알 회오리(궁극기)

    public float bulletSpeed;

    //옥수수알 오브젝트
    public GameObject earFactory;

    //발사 할 위치
    public Transform firePosition;

    //발사 할 힘
    public float throwPower = 10.0f;

    //총알 이펙트 게임 오브젝트
    public GameObject earEffect;

    //총알 공격력
    static public int attackPower = 2;

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

    //bulletUI
    bulletUI sm;

    void Start()
    {
        //초기모드는 일반 모드
        //gMode = GameMode.Normal;

        //gameobject 생성
        GameObject smObject = GameObject.Find("BulletUIManager");
        //bulletUI 컴포넌트 가져옴
        sm = smObject.GetComponent<bulletUI>();
    }



    // Update is called once per frame
    void Update()
    {
       /*
        //마우스 좌클릭
        if (Input.GetMouseButtonDown(0))
        {
            //1. 레이 생성
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            //2. 레이에 부딪힌 대상의 정보 저장할 변수
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

        */

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(0, 0, 0);
            transform.position += dir * bulletSpeed * Time.deltaTime;

            //마우스 좌클릭
            if (Input.GetMouseButtonDown(0))
            {
                //총알 생성
                GameObject bullet = Instantiate(earFactory);

            bullet.transform.position = firePosition.transform.position;

            //개수 변경 적용
            sm.CurrentBullet--;

            //부딪힌 위치에 총알 이펙트 위치시킴
            // earEffect.transform.position = firePosition.position;

            //총알 이펙트 방향을 부딪힌 오브젝트와 수직방향과 일치시킴
            // earEffect.transform.forward = firePosition.forward;

            //총알 이펙트 플레이함
            // ps.Play();
            }

    }
}
