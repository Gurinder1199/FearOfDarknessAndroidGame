using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameCountDown : MonoBehaviour
{
    public Text countDown;
    float currentTime;
    int minutes;
    int seconds;
    string currentTimeText;

    void Start()
    {
        currentTime = PlayerPrefs.GetInt("countdownMinutes") * 60;
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= 1 * (Time.deltaTime);
            showTime();
        }
    }

    void showTime()
    {
        minutes = (int)currentTime / 60;
        seconds = (int)currentTime % 60;
        currentTimeText = string.Format("{0:00}:{1:00 }", minutes, seconds);
        countDown.text = currentTimeText;
    }
}
