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
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트
    int time = 0;

    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

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
        yield return StartCoroutine(NormalChat("", "세상에 있는 모든 옥수수들은 모두 같은 꿈을 가지고 있다."));
        yield return StartCoroutine(NormalChat("", "그건 바로..."));//1
        yield return StartCoroutine(NormalChat("", "맛있는 음식이 되는 것!"));//2
        yield return StartCoroutine(NormalChat("", "콘스프, 팝콘, 삶은 옥수수 등... 각자 다양한 꿈을 안고 살아간다."));//3
        yield return StartCoroutine(NormalChat("", "옥슈슈 : 다들... 진부해."));//4
        yield return StartCoroutine(NormalChat("", "옥슈슈 : 사람들은 팝콘에 큰 관심이 없어."));
        yield return StartCoroutine(NormalChat("", "옥슈슈 : 그저 영화를 보며 심심한 입을 달래기 위한 수단일 뿐이라고."));
        yield return StartCoroutine(NormalChat("", "옥슈슈 : 콘스프는 한국인들의 밥상에 어울리지 않아."));//7



        yield return StartCoroutine(NormalChat("옥슈슈", "나 옥슈슈."));//8
        yield return StartCoroutine(NormalChat("옥슈슈", "한입 한입 정성스레 먹으며 음미할 수 있는,"));//9
        yield return StartCoroutine(NormalChat("옥슈슈", "세상에서 제일 맛있는 콘치즈가 되고야 말겠어!"));//10

    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // 버튼 눌리면 그냥 다 출력하게 함
//                isButtonClicked = false;
//            }