using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiesKilled : MonoBehaviour
{
    public int points = 0;
    public Text pointsText;

    public int zombiesKilled = 0;
    public Text killsText;

    public void IncrementPoints()
    {
        points += 10;
        zombiesKilled += 1;
    }

    void Update()
    {
        killsText.text = zombiesKilled.ToString("KILLS : 00");
        pointsText.text = points.ToString("POINTS : 00");
    }
}
