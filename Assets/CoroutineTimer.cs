using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTimer : MonoBehaviour
{
    public Text countdownTimer;
    float seconds = 3f;

    void Start()
    {
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
    }
}
