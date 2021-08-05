using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire3 : MonoBehaviour
{
    // 좌클릭 할 때 옥수수알(총알) 발사

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

    //플레이어 위치
    public GameObject target;

    //bulletUI
    stage3pool sm;

    void Update()
    {
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
            stage3pool.CurrentBullet--;
        }
    }
}
