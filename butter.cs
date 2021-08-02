using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butter : MonoBehaviour
{
    //포션
    public GameObject[] potions = new GameObject[4];
    Transform trans;
    GameObject obj;

    static public float butterSpeed = 2;
    public int HpButt = 1;

    Vector3 dir;

    GameObject obstacle;

    void Start()
    {
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();

            //->방향
            dir = Vector3.left;
    }

    void Update()
    {
        if (HpButt == 0)
        {
            Destroy(gameObject);

            enemyFactory.CountDiedButt++;
        }

        transform.position += dir * butterSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(HpButt);

        if (collision.gameObject.tag == "Bullet")
        {
            HpButt--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name.Contains("obstacle"))
        {
            obstacle.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("bullet"))
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
