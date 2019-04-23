using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;

    void Update()
    {
        time += 1 * Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }
}
