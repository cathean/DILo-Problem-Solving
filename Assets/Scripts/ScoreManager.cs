using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;

    Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    public void IncreaseScore(int increase)
    {
        currentScore += increase;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
