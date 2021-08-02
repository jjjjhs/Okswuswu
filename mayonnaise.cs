using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayonnaise : MonoBehaviour
{
    //���� 4�� = ������Ʈ �迭 4��
    public GameObject[] potions = new GameObject[4];
    Transform trans;
    GameObject obj;

    //������� �ӵ�
    static public float mayoSpeed = 3;

    //������� ü��
    public int HpMayo = 2;

    Vector3 dir;

    // ĳ���� ��Ʈ�ѷ� ����
    CharacterController cc;


    void Start()
    {
            //->������ �Ʒ���
            dir = Vector3.left;
    }

    void Update()
    {
        transform.position += dir * mayoSpeed * Time.deltaTime;

        if (HpMayo == 0)
        {
            Destroy(gameObject);
            enemyFactory.CountDiedMayo++;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            HpMayo--;
            Destroy(collision.gameObject);
        }

    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Potion"))
        {
            Vector3 dir = new Vector3(0f, -1f, 1f); //��ġ!
            transform.position = other.transform.position + dir;
            StartCoroutine("dropPotion");
        }
    }
    IEnumerator dropPotion()
    {
        int maxpotion = 10;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < maxpotion; i++)
        {
            int rand = Random.Range(0, 9);
            yield return new WaitForSeconds(0.3f);
            Instantiate(potions[rand]);
        }
        Destroy(this.gameObject);
    }
}

