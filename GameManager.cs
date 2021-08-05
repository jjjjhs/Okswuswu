using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //�̱���-�ν��Ͻ��� �ϳ��� �����ϵ��� ��(���� ����)
    public static GameManager gm;

    //�������� ����
    public int stage1clear = 10;
    public int stage2clear = 30;
    public int stage3clear = 50;

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


    //ui
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

    void Start()
    {
        //�ʱ� ���� ����
        //prologue �����ָ� ���� ����

        //�÷��̾� ���� ������Ʈ �˻�
        player = GameObject.Find("Player"); //'�÷��̾�' �˻� -> Capsule�� ������ �÷��̾�(������)�� �����ϸ� ��.
    }

    void Update()
    {
        //�������� �̵�
        if (mayonnaiseFactory.CountDiedMayo >= stage2clear)
        {
            //��������3���� �̵�
            SceneManager.LoadScene("Stage1 2");
            mayonnaiseFactory.CountDiedMayo = 0;
        }
        else if (butterFactory.CountDiedButt >= 10)
        {
            //��������2 �� �̵�
            SceneManager.LoadScene("Stage1 1");
            butterFactory.CountDiedButt = 0;
        }

        //badending
        //1. ���� �÷��̾��� hp�� 0���϶�� ��忣��
        if (PlayerMove.hp <= 0)
        {
            //��忣�� ���� 
            SceneManager.LoadScene("Ending_bad_die");
        }

        //2. ���� �÷��̾��� �Ѿ� ������ �� �������� �� ��忣��
        if (stage1pool.CurrentBullet == 0 || stage2pool.CurrentBullet == 0 || stage3pool.CurrentBullet == 0)
        {
            //��忣�� ����
            //���ӽ����ϸ� �ٷ� ���
            SceneManager.LoadScene("Ending_bad_born");
        }

        //happyending
        //���� �÷��̾ �Ҵ緮��ŭ ���� ó�� ���� �� ���ǿ���
        if (cheesefactory.CountDiedChee == stage3clear)
        {
            //���ǿ��� ����
            SceneManager.LoadScene("Ending_happy");
        }

        //normalending
        //ü���� ������ ������ ü�� ��� �� ��ֿ���
        if (PlayerMove.hp > 0 && PlayerMove.hp < 5) //5�� �÷��̾� ü���� ������.-->���� ����
        {
            //��ֿ��� ����
            SceneManager.LoadScene("Ending_normal");
        }
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
        Time.timeScale = 1;
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
        SceneManager.LoadScene("Main 0");

        // ���� ���� �� �ʱ�ȭ
        butterFactory.CountDiedButt = 0;
        mayonnaiseFactory.CountDiedMayo = 0;
        cheesefactory.CountDiedChee = 0;
    }
}