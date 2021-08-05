using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_normal : MonoBehaviour
{
    public GameObject normal;
    public GameObject people;
    public GameObject corn;
    public GameObject corn2;
    public GameObject black;
    public GameObject black2;
    public Text ChatText; // ���� ä���� ������ �ؽ�Ʈ
    public Text CharacterName; // ĳ���� �̸��� ������ �ؽ�Ʈ
    int time = 0;

    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
        people.SetActive(false);
        corn.SetActive(false);
        corn2.SetActive(false);
        black.SetActive(false);
        black2.SetActive(false);
        normal.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isButtonClicked = true;
            time++;
        }
        if (time == 3)
        {
            people.SetActive(true);

        }
        if (time == 7)
        {
            people.SetActive(false);
            corn.SetActive(true);
            normal.SetActive(false);
            

        }
        if (time ==12)
        {
            corn2.SetActive(true);
            black.SetActive(true);



        }
        if (time == 16)
        {
            black2.SetActive(true);
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
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("�����", "��, ��ġ���. �� �� �Ծ��?"));
        yield return StartCoroutine(NormalChat("������", "(����ȴ�...! � ���� ���ְ� �Ծ���!)")); 
        yield return StartCoroutine(NormalChat("�����", "(��ġ� �Ա� �����Ѵ�.)"));
        yield return StartCoroutine(NormalChat("�����", "....")); //3
        yield return StartCoroutine(NormalChat("�����", "�̰� ���� ������.")); 
        yield return StartCoroutine(NormalChat("�����", "�׳�...�׷�..."));
        yield return StartCoroutine(NormalChat("�����", "��, �� ���ִ� �����̳� ����."));
        yield return StartCoroutine(NormalChat("������", "��...."));//7
        yield return StartCoroutine(NormalChat("������", "��ü ��...?")); 
        yield return StartCoroutine(NormalChat("������", "����... ��ġ� �Ǳ� ���� �󸶳� ������ ����ߴµ�...!"));
        yield return StartCoroutine(NormalChat("������", "�̷���... ���� �� ����..."));
        yield return StartCoroutine(NormalChat("ENDING", "NORMAL ENDING <���� �� ���� ��>"));
        yield return StartCoroutine(NormalChat("HINT", "..."));//11
        yield return StartCoroutine(NormalChat("HINT", "�������� ü���� ǰ���� �ǹ��մϴ�."));//11
        yield return StartCoroutine(NormalChat("HINT", "ü���� ������ ���� ǰ��, �� ������ ���� �������ٴ� �ǹ���."));
        yield return StartCoroutine(NormalChat("HINT", "�ֻ��� ü���� ������ �������� ���� �̷�� �ּ���."));//13


    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // ��ư ������ �׳� �� ����ϰ� ��
//                isButtonClicked = false;
//            }