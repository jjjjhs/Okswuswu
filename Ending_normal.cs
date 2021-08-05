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
        yield return StartCoroutine(NormalChat("사람들", "(콘치즈를 먹기 시작한다.)"));
        yield return StartCoroutine(NormalChat("사람들", "....")); //3
        yield return StartCoroutine(NormalChat("사람들", "이게 무슨 맛이지.")); 
        yield return StartCoroutine(NormalChat("사람들", "그냥...그래..."));
        yield return StartCoroutine(NormalChat("사람들", "쩝, 더 맛있는 음식이나 먹자."));
        yield return StartCoroutine(NormalChat("옥슈슈", "왜...."));//7
        yield return StartCoroutine(NormalChat("옥슈슈", "대체 왜...?")); 
        yield return StartCoroutine(NormalChat("옥슈슈", "내가... 콘치즈가 되기 위해 얼마나 열심히 노력했는데...!"));
        yield return StartCoroutine(NormalChat("옥슈슈", "이렇게... 끝날 수 없어..."));
        yield return StartCoroutine(NormalChat("ENDING", "NORMAL ENDING <믿을 수 없는 꿈>"));
        yield return StartCoroutine(NormalChat("HINT", "..."));//11
        yield return StartCoroutine(NormalChat("HINT", "옥수수의 체력은 품질을 의미합니다."));//11
        yield return StartCoroutine(NormalChat("HINT", "체력이 떨어질 수록 품질, 즉 음식의 맛이 떨어진다는 의미죠."));
        yield return StartCoroutine(NormalChat("HINT", "최상의 체력을 유지해 옥슈슈의 꿈을 이루어 주세요."));//13


    }
}


//
//            if (isButtonClicked)
//            {
//                ChatText.text = narration;
//                a = narration.Length; // 버튼 눌리면 그냥 다 출력하게 함
//                isButtonClicked = false;
//            }