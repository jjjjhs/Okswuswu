using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //싱글턴-인스턴스를 하나만 생성하도록 함(버그 줄임)
    public static GameManager gm;

    //스테이지 기준
    public int stage1clear = 10;
    public int stage2clear = 30;
    public int stage3clear = 50;

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


    //ui
    //옵션 메뉴 유아이 오브젝트
    public GameObject option;


    //플레이어 게임 오브젝트 변수
    GameObject player;

    //플레이어 무브 컴포넌트 변수
    PlayerMove playerM;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    void Start()
    {
        //초기 게임 상태
        //prologue 보여주며 게임 시작

        //플레이어 게임 오브젝트 검색
        player = GameObject.Find("Player"); //'플레이어' 검색 -> Capsule을 게임의 플레이어(옥수수)로 변경하면 됨.
    }

    void Update()
    {
        //스테이지 이동
        if (mayonnaiseFactory.CountDiedMayo >= stage2clear)
        {
            //스테이지3으로 이동
            SceneManager.LoadScene("Stage1 2");
            mayonnaiseFactory.CountDiedMayo = 0;
        }
        else if (butterFactory.CountDiedButt >= 10)
        {
            //스테이지2 로 이동
            SceneManager.LoadScene("Stage1 1");
            butterFactory.CountDiedButt = 0;
        }

        //badending
        //1. 만약 플레이어의 hp가 0이하라면 배드엔딩
        if (PlayerMove.hp <= 0)
        {
            //배드엔딩 연결 
            SceneManager.LoadScene("Ending_bad_die");
        }

        //2. 만약 플레이어의 총알 개수가 다 떨어졌을 시 배드엔딩
        if (stage1pool.CurrentBullet == 0 || stage2pool.CurrentBullet == 0 || stage3pool.CurrentBullet == 0)
        {
            //배드엔딩 연결
            //게임시작하면 바로 출력
            SceneManager.LoadScene("Ending_bad_born");
        }

        //happyending
        //만약 플레이어가 할당량만큼 적을 처지 했을 시 해피엔딩
        if (cheesefactory.CountDiedChee == stage3clear)
        {
            //해피엔딩 연결
            SceneManager.LoadScene("Ending_happy");
        }

        //normalending
        //체력이 일정량 이하인 체로 통과 시 노멀엔딩
        if (PlayerMove.hp > 0 && PlayerMove.hp < 5) //5는 플레이어 체력의 일정량.-->조절 가능
        {
            //노멀엔딩 연결
            SceneManager.LoadScene("Ending_normal");
        }
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
        Time.timeScale = 1;
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
        SceneManager.LoadScene("Main 0");

        // 죽인 적의 수 초기화
        butterFactory.CountDiedButt = 0;
        mayonnaiseFactory.CountDiedMayo = 0;
        cheesefactory.CountDiedChee = 0;
    }
}