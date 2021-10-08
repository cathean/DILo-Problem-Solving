using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager9 : MonoBehaviour
{
    int currentScore = 0;
    int currentLives = 3;

    public Text scoreText;
    public Text livesText;

    private void Awake()
    {
    }

    public void IncreaseScore(int increase)
    {
        currentScore += increase;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void DecreaseLives(int lives)
    {
        currentLives -= lives;
        UpdateLives();
    }

    private void UpdateLives()
    {
        livesText.text = currentLives.ToString();
    }
}
