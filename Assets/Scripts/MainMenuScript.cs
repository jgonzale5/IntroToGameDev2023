using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        Debug.Log("Start");
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }
}
