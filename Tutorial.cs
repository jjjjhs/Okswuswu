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
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트


    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

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
            print("hmm출력"); //ok

        }
        if (time == 6)
        {

            Hmmm.SetActive(false);
            enemy.SetActive(true);

            smile.SetActive(true); //ok
            print("enemy출력");
        }
        if (time == 8)
        {

            smile.SetActive(false);
            enemy.SetActive(false);
            normal.SetActive(true);//ok
            print("normal출력");

        }
        if (time == 10)
        {
            potion.SetActive(true);
        }
        if(time == 12)
        {
            normal.SetActive(false);
            Hmmm.SetActive(true);
            print("Hmm출력");//ok
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
        yield return StartCoroutine(NormalChat("옥슈슈", "안녕!"));
        yield return StartCoroutine(NormalChat("옥슈슈", "내 이름은 옥슈슈라고 해!"));
        yield return StartCoroutine(NormalChat("옥슈슈", "처음 보는 너를 위해 내가 게임 방법을 친절히 알려줄게!"));
        yield return StartCoroutine(NormalChat("옥슈슈", "마우스 좌클릭은, 우리가 소위 말하는 공격이야."));
        yield return StartCoroutine(NormalChat("옥슈슈", "하나의 옥수수알이 발사되며, 적을 맞출 수 있어."));
        yield return StartCoroutine(NormalChat("옥슈슈", "적이 누구냐고?")); //5
        yield return StartCoroutine(NormalChat("옥슈슈", "당연히 콘치즈가 되는 재료들이지!"));
        yield return StartCoroutine(NormalChat("옥슈슈", "이 친구들을 모두 얻으면 나는 콘치즈가 될 수 있어."));
        yield return StartCoroutine(NormalChat("옥슈슈", "꽤나 무서운 녀석들이니 얕보면 안돼!"));
        yield return StartCoroutine(NormalChat("옥슈슈", "... 그렇다고 너무 불안해하지는 마."));//9
        yield return StartCoroutine(NormalChat("옥슈슈", "열심히 게임을 하다 보면 랜덤의 확률로 포션도 얻을 수 있거든~"));
        yield return StartCoroutine(NormalChat("옥슈슈", "종류는 이렇게 4가지가 있어."));
        yield return StartCoroutine(NormalChat("옥슈슈", "외우기 힘들다고?"));//12
        yield return StartCoroutine(NormalChat("옥슈슈", "뭐...어차피 구별할 것 없이 다 먹을 거 아니었어?"));
        yield return StartCoroutine(NormalChat("옥슈슈", "좋은 효과들만 있으니 대충 보고 그냥 먹어~"));//14
        yield return StartCoroutine(NormalChat("옥슈슈", "으... 알려주기 귀찮아!!! 설명보다는 실전인 거 알지?"));//15
        yield return StartCoroutine(NormalChat("옥슈슈", "차차 익혀나가면 되니까."));
        yield return StartCoroutine(NormalChat("옥슈슈", "자, 그럼 바로 가보자!"));//17
    }

}
