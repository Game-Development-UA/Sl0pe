using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float time = 0;
    public Text timeText;


    void Update()
    {
        timeText.text = time.ToString("TIME : 00");
        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }
}
