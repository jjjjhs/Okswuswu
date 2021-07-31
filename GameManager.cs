using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //싱글턴-인스턴스를 하나만 생성하도록 함(버그 줄임)
    public static GameManager gm;


    //게임 상태 상수
    public enum GameState
    {
        Prologue,
        Run,
        GameOver,
        Pause
    }


    //게임 상태 변수
    public GameState gState;
        
    //배드엔딩 스프라이트 변수
    public GameObject badending;
    public GameObject happyending;
    public GameObject normalending;



    //ui
    //이미지 변수
    public Image endingImage;


    //text변수
    public Text endingText;

    //옵션 메뉴 유아이 오브젝트
    public GameObject option;


    //플레이어 게임 오브젝트 변수
    GameObject player;

    //플레이어 무브 컴포넌트 변수
    playerMove playerM;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }



   
    // Start is called before the first frame update
    void Start()
    {
        //초기 게임 상태
        //prologue 보여주며 게임 시작

        //플레이어 게임 오브젝트 검색
        player = GameObject.Find("Capsule"); //'플레이어' 검색 -> Capsule을 게임의 플레이어(옥수수)로 변경하면 됨.
    }


    // Update is called once per frame
    void Update()
    {
        //badending
        //1. 만약 플레이어의 hp가 0이하라면 배드엔딩
        if(playerM.hp<=0)
        {
            //게임오버 문구 출력
            endingText.text = "Game Over..";
            Badending();
        }

        //2. 만약 플레이어의 총알 개수가 다 떨어졌을 시 배드엔딩




        //happyending
        //만약 플레이어가 할당량만큼 적을 처지 했을 시 해피엔딩



        //normalending
        //체력이 일정량 이하인 체로 통과 시 노멀엔딩
        if(playerM.hp>0&&playerM.hp<5) //5는 플에이어 체력의 일정 량.-->조절 가능
        {
            //try again 문구 출력
            endingText.text = "Try Again!";
            Normalending();
        }
    }




    IEnumerator Badending()
    {
        gState = GameState.GameOver;
        badending.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }


    IEnumerator Happyending()
    {
        gState = GameState.GameOver;
        happyending.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator Normalending()
    {
        gState = GameState.GameOver;
        normalending.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }


    public void OpenOption()
    {
        gState = GameState.Pause;

        //시간 멈춤(게임 움직임 멈춤)
        Time.timeScale = 0;

        //옵션 메뉴창 활성화
        option.SetActive(true);

    }


    //옵션 끄기
    public void CloseOption()
    {
        //시간을 1배로 되돌림
        Time.timeScale = 1;

        //옵션메뉴 창을 비활성화
        option.SetActive(false);

        gState = GameState.Run;
    }



    //현재 씬 다시 로드
    public void GameRestart()
    {
        //시간을 1배로 되돌림
        Time.timeScale = 1;

        //현재 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //게임 종료
    public void GameQuit()
    {
        //어플리케이션 종료
        Application.Quit();
    }





}
