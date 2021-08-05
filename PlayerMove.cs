using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMove : MonoBehaviour
{
    //ĳ���� ������Ʈ ����
    CharacterController cc;

    //�߷º���
    public float gravity = -20.0f;

    //�����ӵ�����
    float yVelocity = 0;

    //������
    public float jumpPower = 10;

    //�ӵ�����
    static public float moveSpeed = 7.0f;

    //�ִ� ���� Ƚ��
    public int maxJump = 2;

    //���� ���� Ƚ��
    int jumpCount = 0;

    //���� ü�� ����
    static public int hp;

    //�����̴� ui
    public Slider hpSlider;

    //����Ʈ UI ������Ʈ
    public GameObject hitEffect;

    //�ִ� ü��
    static public int maxHp = 10;

    //�ִϸ����� ������Ʈ ����
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
        //character component �ҷ�����
        cc = GetComponent<CharacterController>();

        //ü�º��� �ʱ�ȭ
        hp = maxHp;

        AudioSource audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //���� ����
        Vector3 dir = new Vector3(0, 0, 0);
        dir.Normalize();

        //�÷��̾� ���� ���� �� ���� ���� Ƚ�� 0�� �ʱ�ȭ
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            jumpCount = 0;
            yVelocity = 0;
        }
        //���� ����Ű ������ �������� �����ӵ��� ����(���� ���� Ƚ��<�ִ����� Ƚ�� �� ��)
        if (Input.GetButtonDown("Jump") && (jumpCount < maxJump))
        {
            jumpCount++;
            yVelocity = jumpPower;
            AudioSource jump = GetComponent<AudioSource>();
            jump.Play();
        }


        //ĳ���Ϳ� �߷� �ۿ�
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //�����̴��� value�� ü�� ������ ����
        hpSlider.value = (float)hp / (float)maxHp;


        //�̵��������� �÷��̾� �̵� �� �浹ó��
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
    //�÷��̾� �ǰ� �Լ�
    public void onDamage(int value)
    {
        hp -= value;
        if (hp < 0)
        {
            hp = 0;
        }
        //hp�� 0���� ū ��� �ǰ� ����Ʈ �ڷ�ƾ ����
        else
        {
            StartCoroutine(HitEffect());
        }
    }

    IEnumerator HitEffect()
    {
        //1. ����Ʈ Ȱ��ȭ
        hitEffect.SetActive(true);

        //2. 0.3�� ��ٸ�
        yield return new WaitForSeconds(0.3f);

        //3. ����Ʈ ��Ȱ��ȭ
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