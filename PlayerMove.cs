using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    //���ڸ����� ����� �ٲٸ�(�޸��� ���-�̹��� ���� �ݺ�) ����Ű�� ������ �����ϰ� �����ʹ�

    //ĳ���� ������Ʈ ����
    CharacterController cc;

    //�߷º���
    public float gravity = -20.0f;

    //�����ӵ�����
    float yVelocity = 0;

    //������
    public float jumpPower = 10;

    //�ӵ�����
    public float moveSpeed = 7.0f;



    //�ִ� ���� Ƚ��
    public int maxJump = 2;

    //���� ���� Ƚ��
    int jumpCount = 0;








    //���� ü�� ����
    public int hp;

    //�����̴� ui
    public Slider hpSlider;

    //����Ʈ UI ������Ʈ
    public GameObject hitEffect;

    //�ִ� ü��
    public int maxHp = 10;

    //�ִϸ����� ������Ʈ ����
    Animator anim;


    void Start()
    {
        //character component �ҷ�����
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    { 
        //���� ����
        Vector3 dir = new Vector3(0, 0, 0);
        dir.Normalize();

        //�÷��̾� ���� ���� �� ���� ���� Ƚ�� 0�� �ʱ�ȭ
        if(cc.collisionFlags==CollisionFlags.Below)
        {
            jumpCount = 0;
            yVelocity = 0;
        }
        //���� ����Ű ������ �������� �����ӵ��� ����(���� ���� Ƚ��<�ִ����� Ƚ�� �� ��)
        if(Input.GetButtonDown("Jump")&&(jumpCount<maxJump))
        {
            jumpCount++;
            yVelocity = jumpPower;
        }


        //ĳ���Ϳ� �߷� �ۿ�
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //�̵��������� �÷��̾� �̵� �� �浹ó��
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }



    //�ÿ��̾� �ǰ� �Լ�
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
