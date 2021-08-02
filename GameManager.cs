using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //�̱���-�ν��Ͻ��� �ϳ��� �����ϵ��� ��(���� ����)
    public static GameManager gm;


    //���� ���� ���
    public enum GameState
    {
        Prologue,
        Run,
        GameOver,
        Pause
    }


    //���� ���� ����
    public GameState gState;

    //��忣�� ��������Ʈ ����
    public GameObject badending;
    public GameObject happyending;
    public GameObject normalending;



    //ui
    //�̹��� ����
    public Image endingImage;


    //text����
    public Text endingText;

    //�ɼ� �޴� ������ ������Ʈ
    public GameObject option;


    //�÷��̾� ���� ������Ʈ ����
    GameObject player;

    //�÷��̾� ���� ������Ʈ ����
    PlayerMove playerM;

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
        //�ʱ� ���� ����
        //prologue �����ָ� ���� ����

        //�÷��̾� ���� ������Ʈ �˻�
        player = GameObject.Find("Capsule"); //'�÷��̾�' �˻� -> Capsule�� ������ �÷��̾�(������)�� �����ϸ� ��.
    }


    // Update is called once per frame
    void Update()
    {
        //badending
        //1. ���� �÷��̾��� hp�� 0���϶�� ��忣��
        if (PlayerMove.hp <= 0)
        {
            //���ӿ��� ���� ���
            endingText.text = "Game Over..";
            Badending();
        }

        //2. ���� �÷��̾��� �Ѿ� ������ �� �������� �� ��忣��




        //happyending
        //���� �÷��̾ �Ҵ緮��ŭ ���� ó�� ���� �� ���ǿ���



        //normalending
        //ü���� ������ ������ ü�� ��� �� ��ֿ���
        if (PlayerMove.hp > 0 && PlayerMove.hp < 5) //5�� �ÿ��̾� ü���� ���� ��.-->���� ����
        {
            //try again ���� ���
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

        //�ð� ����(���� ������ ����)
        Time.timeScale = 0;

        //�ɼ� �޴�â Ȱ��ȭ
        option.SetActive(true);

    }


    //�ɼ� ����
    public void CloseOption()
    {
        //�ð��� 1��� �ǵ���
        Time.timeScale = 1;

        //�ɼǸ޴� â�� ��Ȱ��ȭ
        option.SetActive(false);

        gState = GameState.Run;
    }



    //���� �� �ٽ� �ε�
    public void GameRestart()
    {
        //�ð��� 1��� �ǵ���
        Time.timeScale = 1;

        //���� �� �ٽ� �ε�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //���� ����
    public void GameQuit()
    {
        //���ø����̼� ����
        Application.Quit();
    }





}