using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionDrop : MonoBehaviour
{
    //���� 4�� = ������Ʈ �迭 4��
    public GameObject[] potions = new GameObject[4];

    Transform trans;
    GameObject obj;

    void Start()
    {
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Bullet"))
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
        for(int i=0; i<maxpotion; i++)
        {
            //int rand = Random.Range(0, 9);
            yield return new WaitForSeconds(0.3f);
            Instantiate(potions[rand]);
        }
        Destroy(this.gameObject);
    }
}

