using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject PauseUI;
    // Start is called before the first frame update

    public void TogglePause()
    {
        if (gamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    // Update is called once per frame
    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0.01f;
        gamePaused = true;
    }

    public void ReturnMain()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
