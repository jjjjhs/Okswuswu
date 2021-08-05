using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    float timer;
    int waitingTime;
    public GameObject BlackImage;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        BlackImage.SetActive(true);
        ui.SetActive(true);
        timer = 0.0f;
        waitingTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            BlackImage.SetActive(false);
            ui.SetActive(false);
            timer = 0;

        }
    }
}