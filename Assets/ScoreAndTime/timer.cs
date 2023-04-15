using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float currentTime;
    private bool timerStart = false;

    private void Start()
    {
        currentTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Timer")
        {
            timerStart = true;
        }
    }

    void Update()
    {
        if (timerStart == true)
        {
            currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
        }

        if (Time.timeScale == 0f)
        {
            PlayerPrefs.SetFloat("timeScore",currentTime);
        }

    }

    public void setCurrentTime(float time)
    {
        currentTime = time;
    }

    public float getCurrentTime()
    {
        return currentTime;
    }

}
