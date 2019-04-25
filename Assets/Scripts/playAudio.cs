using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playAudio : MonoBehaviour
{
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
