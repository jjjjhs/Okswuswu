using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_bad_born: MonoBehaviour
{
    public GameObject popcorn;
    public GameObject black;
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트
    int time = 0;

    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
        popcorn.SetActive(false);
        black.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            {
            isButtonClicked = true;
            time++;
        }
        if (time ==5)
        {
            black.SetActive(true);
            popcorn.SetActive(true);
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
        yield return StartCoroutine(NormalChat("옥슈슈", "크윽........"));
        yield return StartCoroutine(NormalChat("옥슈슈", "옥수수 알을 ... 다 써버렸어..."));
        yield return StartCoroutine(NormalChat("옥슈슈", "나.... 콘치즈가.... 되고 싶었는데....."));
        yield return StartCoroutine(NormalChat("옥슈슈", "(끝내 숨을 거두었다.)"));
        yield return StartCoroutine(NormalChat("Ending", "BAD ENDING <옥수수알을 소중히 아끼자>"));

    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // 버튼 눌리면 그냥 다 출력하게 함
//                isButtonClicked = false;
//            }