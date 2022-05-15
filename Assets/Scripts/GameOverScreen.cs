using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOverMenu;

    public void SetScreen()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");

    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");

    }
}
