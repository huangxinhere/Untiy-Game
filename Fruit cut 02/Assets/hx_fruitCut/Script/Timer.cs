using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /*״̬*/
    bool run = false;
    //bool stop = false;
    bool timeEnd = false;
    bool pause = false;

    bool showTimeLeft = true;//�Ƿ񵹼�ʱ

    /*ʱ�����*/
    float startTime = 0.0f;
    float curTime = 0.0f;
    float showTime = 0.0f;
    float timeAvailable = 30f;  //30seconds����ʱ

    string curStrTime = string.Empty;
    public Text guiTimer;

    public GameObject spawn;

    void Start()
    {
        RunTimer();
    }
    
    public void RunTimer()
    {
        run = true;

        //��¼��ʼ��ʱ��
        startTime = Time.time;
    }

    public void PauseTimer(bool b)
    {
        pause = b;
    }

    void Update()
    {
        if (pause)
        {
            startTime = startTime + Time.deltaTime;
        }

        if (timeEnd)
        {
            if(spawn != null)
            {
                spawn.SetActive(false);
            }
            GameObject.Find("AllCanvas/RestartCanvas/TimeOutPanel").SetActive(true);
            GameObject game = GameObject.Find("Game");
            game.GetComponent<Result>().ShowPoints();
        }

        if (run)
        {
            //��¼�Ѿ������˶೤ʱ��
            curTime = Time.time - startTime;
        }

        if (showTimeLeft)
        {
            showTime = timeAvailable - curTime;
            if(showTime <= 0)
            {
                timeEnd = true;
                showTime = 0;
            }
        }

        int minute = (int)(showTime / 60);
        int seconds = (int)(showTime % 60);
        int fraction = (int)((showTime * 100) % 100);

        curStrTime = string.Format("{0:00}:{1:00}:{2:00}", minute, seconds, fraction);
        guiTimer.text = "ʱ�� " + curStrTime;
    }
}
