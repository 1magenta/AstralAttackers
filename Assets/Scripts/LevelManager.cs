using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager S;

    public string levelName; // string to display at level start
    public string nextScene; // name of the scene we move to if successful

    public GameObject levelMotherShipObject;

    private void Awake()
    {
        S = this; // singleton definition
    }

    private void Start()
    {
        GameManager.S.LevelStarted();
    }

    public void GoToNextRound()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void GoToEndGameScene()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void ReloadLevel()
    {
        // reload the same scene we are currently in
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
