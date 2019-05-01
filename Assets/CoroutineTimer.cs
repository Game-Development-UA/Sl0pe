using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTimer : MonoBehaviour
{
    public Text countdownTimer;

    void Start()
    {
        StartCoroutine(gameCountdown());
    }

    private IEnumerator gameCountdown()
    {
        float seconds = 3f;
        float normalizedTime = 0;

        while (normalizedTime <= 1f)
        {
            countdownTimer.text = "" + normalizedTime;
            normalizedTime += Time.deltaTime / seconds;
            yield return null;
        }
    }
}
