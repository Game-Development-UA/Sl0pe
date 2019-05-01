using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTimer : MonoBehaviour
{
    public Text countdownTimer;
    public Canvas canvas;
    float seconds = 3f;

    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(gameCountdown());
    }

    private IEnumerator gameCountdown()
    {

        while (seconds > 0)
        {
            countdownTimer.text = seconds.ToString();
            yield return new WaitForSeconds(1.0f);
            seconds--;
        }

        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
