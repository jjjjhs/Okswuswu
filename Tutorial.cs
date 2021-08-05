using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public GameObject mouse;
    public GameObject potion;
    public GameObject enemy;
    public GameObject bullet;
    public GameObject normal;
    public GameObject happy;
    public GameObject Hmmm;
    public GameObject smile;
    int time = 0;
    public Text ChatText; // ���� ä���� ������ �ؽ�Ʈ
    public Text CharacterName; // ĳ���� �̸��� ������ �ؽ�Ʈ


    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
        mouse.SetActive(false);
        potion.SetActive(false);
        enemy.SetActive(false);
        bullet.SetActive(false);
        happy.SetActive(false);
        Hmmm.SetActive(false);
        smile.SetActive(false);

        normal.SetActive(true);
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            isButtonClicked = true;
            time++;
        }
        if (time == 18)
        {
            SceneManager.LoadScene("Stage1");
        }
    }



    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        //�ؽ�Ʈ Ÿ���� ȿ��
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //Ű�� �ٽ� ���� �� ���� ������ ���
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }

        if(time == 3)
        {
            mouse.SetActive(true);

        }
        if(time == 4)
        {
            bullet.SetActive(true);

        }
        if (time == 5)
        {
            bullet.SetActive(false);
            mouse.SetActive(false);
            normal.SetActive(false);


            Hmmm.SetActive(true);
            print("hmm���"); //ok

        }
        if (time == 6)
        {

            Hmmm.SetActive(false);
            enemy.SetActive(true);

            smile.SetActive(true); //ok
            print("enemy���");
        }
        if (time == 8)
        {

            smile.SetActive(false);
            enemy.SetActive(false);
            normal.SetActive(true);//ok
            print("normal���");

        }
        if (time == 10)
        {
            potion.SetActive(true);
        }
        if(time == 12)
        {
            normal.SetActive(false);
            Hmmm.SetActive(true);
            print("Hmm���");//ok
        }
        if (time == 14)
        {
            Hmmm.SetActive(false);
            smile.SetActive(true);//ok
        }
        if (time == 15)
        {
            potion.SetActive(false);
            smile.SetActive(false);
            normal.SetActive(true);//ok
        }
        if(time == 17)
        {
            normal.SetActive(false);
            happy.SetActive(true);
        }
        

    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("������", "�ȳ�!"));
        yield return StartCoroutine(NormalChat("������", "�� �̸��� ��������� ��!"));
        yield return StartCoroutine(NormalChat("������", "ó�� ���� �ʸ� ���� ���� ���� ����� ģ���� �˷��ٰ�!"));
        yield return StartCoroutine(NormalChat("������", "���콺 ��Ŭ����, �츮�� ���� ���ϴ� �����̾�."));
        yield return StartCoroutine(NormalChat("������", "�ϳ��� ���������� �߻�Ǹ�, ���� ���� �� �־�."));
        yield return StartCoroutine(NormalChat("������", "���� �����İ�?")); //5
        yield return StartCoroutine(NormalChat("������", "�翬�� ��ġ� �Ǵ� ��������!"));
        yield return StartCoroutine(NormalChat("������", "�� ģ������ ��� ������ ���� ��ġ� �� �� �־�."));
        yield return StartCoroutine(NormalChat("������", "�ϳ� ������ �༮���̴� �躸�� �ȵ�!"));
        yield return StartCoroutine(NormalChat("������", "... �׷��ٰ� �ʹ� �Ҿ��������� ��."));//9
        yield return StartCoroutine(NormalChat("������", "������ ������ �ϴ� ���� ������ Ȯ���� ���ǵ� ���� �� �ְŵ�~"));
        yield return StartCoroutine(NormalChat("������", "������ �̷��� 4������ �־�."));
        yield return StartCoroutine(NormalChat("������", "�ܿ�� ����ٰ�?"));//12
        yield return StartCoroutine(NormalChat("������", "��...������ ������ �� ���� �� ���� �� �ƴϾ���?"));
        yield return StartCoroutine(NormalChat("������", "���� ȿ���鸸 ������ ���� ���� �׳� �Ծ�~"));//14
        yield return StartCoroutine(NormalChat("������", "��... �˷��ֱ� ������!!! �����ٴ� ������ �� ����?"));//15
        yield return StartCoroutine(NormalChat("������", "���� ���������� �Ǵϱ�."));
        yield return StartCoroutine(NormalChat("������", "��, �׷� �ٷ� ������!"));//17
    }

}
