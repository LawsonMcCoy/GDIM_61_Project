using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // callback for the play button
    public void PlayButton()
    {
        GameManager.Instance.StartGame();
    }

    // callback for the quit button
    public void QuitGame()
    {
        Application.Quit();
    }
}
