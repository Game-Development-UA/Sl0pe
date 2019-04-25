using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class points : MonoBehaviour
{
    public static float num_points = 0;
    public Text pointsText;

    public static float zKilled = 0;
    public Text killsText;

    public void IncrementPoints()
    {
        num_points += 10;
        zKilled += 1;
    }

    void Update()
    {
        killsText.text = "KILLS : " + zKilled;
        pointsText.text = "POINTS : " + num_points;
    }
}
