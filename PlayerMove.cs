using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMove : MonoBehaviour
{
    //캐릭터 컴포넌트 변수
    CharacterController cc;

    //중력변수
    public float gravity = -20.0f;

    //수직속도변수
    float yVelocity = 0;

    //점프력
    public float jumpPower = 10;

    //속도변수
    static public float moveSpeed = 7.0f;

    //최대 점프 횟수
    public int maxJump = 2;

    //현재 점프 횟수
    int jumpCount = 0;

    //현재 체력 변수
    static public int hp;

    //슬라이더 ui
    public Slider hpSlider;

    //이펙트 UI 오브젝트
    public GameObject hitEffect;

    //최대 체력
    static public int maxHp = 10;

    //애니메이터 컴포넌트 변수
    Animator anim;

    static public int stage1clear = 10;
    static public int stage2clear = 30;
    static public int stage3clear = 50;

    public GameObject SpeedPotion;
    public GameObject StopPotion;
    public GameObject HpPotion;
    public GameObject DamagePotion;
    AudioSource audio;
    enum State
    {
        Idle,
        bumpedPotion,
        whilePotion,
    };
    State state = State.Idle;

    void Start()
    {
        //character component 불러오기
        cc = GetComponent<CharacterController>();

        //체력변수 초기화
        hp = maxHp;

        AudioSource audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //방향 고정
        Vector3 dir = new Vector3(0, 0, 0);
        dir.Normalize();

        //플레이어 땅에 착지 시 현재 점프 횟수 0을 초기화
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            jumpCount = 0;
            yVelocity = 0;
        }
        //만약 점프키 누르면 점프력을 수직속도로 적용(현재 점프 횟수<최대점프 횟수 일 때)
        if (Input.GetButtonDown("Jump") && (jumpCount < maxJump))
        {
            jumpCount++;
            yVelocity = jumpPower;
            AudioSource jump = GetComponent<AudioSource>();
            jump.Play();
        }


        //캐릭터에 중력 작용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //슬라이더의 value를 체력 비율로 적용
        hpSlider.value = (float)hp / (float)maxHp;


        //이동방향으로 플레이어 이동 및 충돌처리
        cc.Move(dir * moveSpeed * Time.deltaTime);

        if (butterFactory.CountDiedButt <= stage1clear)
        {
            int stage2hp = (maxHp - hp) * 70;
            if (stage2hp > maxHp)
            {
                stage2hp = maxHp;
            }
        }
        else if (butterFactory.CountDiedButt > stage1clear && mayonnaiseFactory.CountDiedMayo <= stage2clear)
        {
            int stage3hp = maxHp - hp;
            {
                stage3hp = maxHp;
            }
        }
    }
    //플레이어 피격 함수
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


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            hp -= 2;
            onDamage(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == ("Obstacle"))
        {
            SceneManager.LoadScene("Ending_bad_Popcorn");
        }

        if (other.gameObject.tag == ("StopPotion"))
        {
            StartCoroutine("StPotion");
            audio.Play();
        }

        if (other.gameObject.tag == ("SpeedPotion"))
        {
            StartCoroutine("SpPotion");
            audio.Play();
        }

        if (other.gameObject.tag == ("HpPotion"))
        {
            StartCoroutine("HPotion");
            audio.Play();
        }

        if (other.gameObject.tag == ("DamagePotion"))
        {
            StartCoroutine("DaPotion");
            audio.Play();
        }

    }

    IEnumerator SpPotion()
    {
        PlayerMove.moveSpeed--;
        Background.m_scrollSpeed += 0.1f;
        yield return new WaitForSeconds(2.0f);
        state = State.Idle;
    }


    IEnumerator StPotion()
    {
        cheese.cheeseSpeed = 0;
        mayonnaise.mayoSpeed = 0;
        butter.butterSpeed = 0;

        yield return new WaitForSeconds(2.0f);

        cheese.cheeseSpeed = 4f;
        mayonnaise.mayoSpeed = 3f;
        butter.butterSpeed = 2f;

        state = State.Idle;
    }


    IEnumerator HPotion()
    {
        PlayerMove.hp += 2;
        yield return new WaitForSeconds(2.0f);
        state = State.Idle;
    }


    IEnumerator DaPotion()
    {
        PlayerFire1.attackPower++;
        yield return new WaitForSeconds(2.0f);
        state = State.Idle;
    }

}