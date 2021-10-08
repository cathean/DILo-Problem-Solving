using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public UnityEvent OnGetStar;
    public UnityEvent OnHitMeteor;

    public GameObject player;
    public GameObject gameOverScreen;

    private int currentLives = 3;

    public void SpawnPlayer()
    {
        if(currentLives == 0)
        {
            gameOverScreen.SetActive(true);
            return;
        }

        currentLives--;
        Instantiate(player);
    }

    public void OnClickCobaLagi()
    {
        SceneManager.LoadScene("Problem9");
    }
}
