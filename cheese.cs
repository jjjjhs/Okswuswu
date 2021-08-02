using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheese : MonoBehaviour
{
    //포션 4개 = 오브젝트 배열 4개
    public GameObject[] potions = new GameObject[4];
    Transform trans;
    GameObject obj;

    //치즈 속도
    static public float cheeseSpeed = 4;

    //치즈 체력
    public int HpChee = 3;

    Vector3 dir;

    // 캐릭터 컨트롤러 변수
    CharacterController cc;


    void Start()
    {
            //->방향을 아래로
            dir = Vector3.left;
    }

    void Update()
    {
        transform.position += dir * cheeseSpeed * Time.deltaTime;

        if (HpChee == 0)
        {
            Destroy(gameObject);
            enemyFactory.CountDiedChee++;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HpChee--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigBullet")
        {
            HpChee -= 5;
            Destroy(collision.gameObject);
        }

        if (HpChee == 0)
        {
            Destroy(gameObject);
            enemyFactory.CountDiedChee++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Potion"))
        {
            Vector3 dir = new Vector3(0f, -1f, 1f); //위치!
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



