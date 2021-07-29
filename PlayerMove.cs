using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    //제자리에서 모습을 바꾸며(달리는 모양-이미지 교차 반복) 점프키를 누르면 점프하게 만들고싶다

    //캐릭터 컴포넌트 변수
    CharacterController cc;

    //중력변수
    public float gravity = -20.0f;

    //수직속도변수
    float yVelocity = 0;

    //점프력
    public float jumpPower = 10;

    //속도변수
    public float moveSpeed = 7.0f;



    //최대 점프 횟수
    public int maxJump = 2;

    //현재 점프 횟수
    int jumpCount = 0;








    //현재 체력 변수
    public int hp;

    //슬라이더 ui
    public Slider hpSlider;

    //이펙트 UI 오브젝트
    public GameObject hitEffect;

    //최대 체력
    public int maxHp = 10;

    //애니메이터 컴포넌트 변수
    Animator anim;


    void Start()
    {
        //character component 불러오기
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    { 
        //방향 고정
        Vector3 dir = new Vector3(0, 0, 0);
        dir.Normalize();

        //플레이어 땅에 착지 시 현재 점프 횟수 0을 초기화
        if(cc.collisionFlags==CollisionFlags.Below)
        {
            jumpCount = 0;
            yVelocity = 0;
        }
        //만약 점프키 누르면 점프력을 수직속도로 적용(현재 점프 횟수<최대점프 횟수 일 때)
        if(Input.GetButtonDown("Jump")&&(jumpCount<maxJump))
        {
            jumpCount++;
            yVelocity = jumpPower;
        }


        //캐릭터에 중력 작용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //이동방향으로 플레이어 이동 및 충돌처리
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }



    //플에이어 피격 함수
    public void onDamage(int value)
    {
        hp -= value;
        if (hp < 0)
        {
            hp = 0;
        }
        //hp가 0보다 큰 경우 피격 이펙트 코루틴 실행
        else
        {
            StartCoroutine(HitEffect());
        }
    }

    IEnumerator HitEffect()
    {
        //1. 이펙트 활성화
        hitEffect.SetActive(true);

        //2. 0.3초 기다림
        yield return new WaitForSeconds(0.3f);

        //3. 이펙트 비활성화
        hitEffect.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == butter || collision.gameObject.name == mayonnasie || cheeseFactory == cheese)
        {
            hp -= 5;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("bullet") || other.gameObject.name.Contains("obstacle"))
        {
            hp--;
        }
    }
}
