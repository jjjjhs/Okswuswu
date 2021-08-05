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
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트
    int time = 0;

    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

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

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //키를 다시 누를 떄 까지 무한정 대기
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
        yield return StartCoroutine(NormalChat("사람들", "와, 콘치즈네. 한 번 먹어볼까?"));
        yield return StartCoroutine(NormalChat("옥슈슈", "(긴장된다...! 어서 나를 맛있게 먹어줘!)")); 
        yield return StartCoroutine(NormalChat("사람들", "(콘치즈를 먹기 시작한다.)")); //2
        yield return StartCoroutine(NormalChat("사람들", "!!!!!!!")); 
        yield return StartCoroutine(NormalChat("사람들", "세상에... 너무 맛있어...")); //4
        yield return StartCoroutine(NormalChat("사람들", "최고의 맛이야...흐흑...흑..."));
        yield return StartCoroutine(NormalChat("사람들", "눈물이 나........"));
        yield return StartCoroutine(NormalChat("사람들", "따끈한 치즈처럼... 내 마음도 편안해져...."));
        yield return StartCoroutine(NormalChat("ENDING", "그렇게, 콘치즈로 하여금 사람들은 마음의 평화를 얻었다.")); //8
        yield return StartCoroutine(NormalChat("ENDING", "콘치즈를 한입 먹은 사람들은 분노가 가라앉고"));
        yield return StartCoroutine(NormalChat("ENDING", "눈물을 흘리며 희망과 꿈을 품게되었다고 한다."));
        yield return StartCoroutine(NormalChat("ENDING", "내전과 폭력이 사라진 지구에서는 언제나 따뜻한 콘치즈 냄새가 풍긴다고 한다.")); //11
        yield return StartCoroutine(NormalChat("ENDING", "HAPPY ENDING"));
        yield return StartCoroutine(NormalChat("ENDING", "<옥슈슈의 꿈>"));//13



    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // 버튼 눌리면 그냥 다 출력하게 함
//                isButtonClicked = false;
//            }