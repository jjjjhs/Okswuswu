using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_happy : MonoBehaviour
{
    public GameObject people;
    public GameObject earth;
    public GameObject earth2;
    public GameObject corn;
    public GameObject corn2;
    public GameObject white;
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
        earth.SetActive(false);
        earth2.SetActive(false);
        corn.SetActive(false);
        white.SetActive(false);
        corn2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isButtonClicked = true;
            time++;
        }
        if (time == 4)
        {
            people.SetActive(true);
            corn.SetActive(true);

        }
        if (time == 8)
        {
            people.SetActive(false);
            earth.SetActive(true);
            

        }
        if (time ==11)
        {
            earth2.SetActive(true);
            earth.SetActive(false) ;



        }
        if (time == 14)
        {
            corn2.SetActive(true);
            white.SetActive(true);
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
        yield return StartCoroutine(NormalChat("�����", "(��ġ� �Ա� �����Ѵ�.)")); //2
        yield return StartCoroutine(NormalChat("�����", "!!!!!!!")); 
        yield return StartCoroutine(NormalChat("�����", "����... �ʹ� ���־�...")); //4
        yield return StartCoroutine(NormalChat("�����", "�ְ��� ���̾�...����...��..."));
        yield return StartCoroutine(NormalChat("�����", "������ ��........"));
        yield return StartCoroutine(NormalChat("�����", "������ ġ��ó��... �� ������ �������...."));
        yield return StartCoroutine(NormalChat("ENDING", "�׷���, ��ġ��� �Ͽ��� ������� ������ ��ȭ�� �����.")); //8
        yield return StartCoroutine(NormalChat("ENDING", "��ġ� ���� ���� ������� �г밡 ����ɰ�"));
        yield return StartCoroutine(NormalChat("ENDING", "������ �긮�� ����� ���� ǰ�ԵǾ��ٰ� �Ѵ�."));
        yield return StartCoroutine(NormalChat("ENDING", "������ ������ ����� ���������� ������ ������ ��ġ�� ������ ǳ��ٰ� �Ѵ�.")); //11
        yield return StartCoroutine(NormalChat("ENDING", "HAPPY ENDING"));
        yield return StartCoroutine(NormalChat("ENDING", "<�������� ��>"));//13



    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // ��ư ������ �׳� �� ����ϰ� ��
//                isButtonClicked = false;
//            }