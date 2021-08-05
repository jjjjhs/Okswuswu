using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{

    public GameObject black;
    public GameObject image1;
    public GameObject image2;
    public GameObject behind;
    public GameObject popcorn;
    public GameObject Supe;
    public GameObject swuswu;
    public Text ChatText; // ���� ä���� ������ �ؽ�Ʈ
    public Text CharacterName; // ĳ���� �̸��� ������ �ؽ�Ʈ
    int time = 0;

    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
        black.SetActive(true);
        image1.SetActive(true);
        image2.SetActive(true);

        behind.SetActive(false);
        popcorn.SetActive(false);

        Supe.SetActive(false);

        swuswu.SetActive(false);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isButtonClicked = true;
            time++;
        }
        if (time == 11)
        {
            SceneManager.LoadScene("Tutorial");
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

        if (time == 2)
        {
            image1.SetActive(false);
            behind.SetActive(true);

        }
        if (time == 3)
        {
            image2.SetActive(false);

        }
        if (time == 5)
        {
            behind.SetActive(false);
            popcorn.SetActive(true);
        }
        if (time == 7)
        {
            Supe.SetActive(true);
            popcorn.SetActive(false);
        }
        if (time == 8)
        {
            Supe.SetActive(false);
            swuswu.SetActive(true);
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("", "���� �ִ� ��� ���������� ��� ���� ���� ������ �ִ�."));
        yield return StartCoroutine(NormalChat("", "�װ� �ٷ�..."));//1
        yield return StartCoroutine(NormalChat("", "���ִ� ������ �Ǵ� ��!"));//2
        yield return StartCoroutine(NormalChat("", "�ܽ���, ����, ���� ������ ��... ���� �پ��� ���� �Ȱ� ��ư���."));//3
        yield return StartCoroutine(NormalChat("", "������ : �ٵ�... ������."));//4
        yield return StartCoroutine(NormalChat("", "������ : ������� ���ܿ� ū ������ ����."));
        yield return StartCoroutine(NormalChat("", "������ : ���� ��ȭ�� ���� �ɽ��� ���� �޷��� ���� ������ ���̶��."));
        yield return StartCoroutine(NormalChat("", "������ : �ܽ����� �ѱ��ε��� ��� ��︮�� �ʾ�."));//7



        yield return StartCoroutine(NormalChat("������", "�� ������."));//8
        yield return StartCoroutine(NormalChat("������", "���� ���� �������� ������ ������ �� �ִ�,"));//9
        yield return StartCoroutine(NormalChat("������", "���󿡼� ���� ���ִ� ��ġ� �ǰ�� ���ھ�!"));//10

    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // ��ư ������ �׳� �� ����ϰ� ��
//                isButtonClicked = false;
//            }