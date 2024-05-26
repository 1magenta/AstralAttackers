using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    private void Start()
    {
        if (GameManager.S)
        {
            Destroy(GameManager.S.gameObject);
        }   
    }

    public void btn_StartTheGame()
    {
        Debug.Log("Game Launching");
        SceneManager.LoadScene("Level01");
    }

    public void btn_GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void btn_GoToScene(string thisScene)
    {
        SceneManager.LoadScene(thisScene);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }


}
