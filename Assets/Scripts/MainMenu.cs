using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button[] btn;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < btn.Length; i++)
        {
            int index = i + 1;
            btn[i].onClick.AddListener(() => { SceneManager.LoadScene(index); });
        }
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
