using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Timer : MonoBehaviour
{
    public float time = 50;
    //public static float saved_time = 0;
    public Text timeText;


    void Update()
    {
        timeText.text = "TIME : " + (time - Time.deltaTime);

        if (time <= 0)
        {
            SceneManager.LoadScene(6);

        }
        /*
        timeText.text = time.ToString("TIME : 00");
        time += Time.deltaTime;
        */
    }

    public float GetTime()
    {
        return time;
    }
}
