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
        EventManager.Instance.Notify(EventTypes.Events.GAME_UNPAUSE); //inform other script the game is unpaused
        Time.timeScale = 1f; //reset the time scale
        gamePaused = false;
    }

    // Update is called once per frame
    void Pause()
    {
        PauseUI.SetActive(true);
        EventManager.Instance.Notify(EventTypes.Events.GAME_PAUSE); //inform other scripts the game is paused
        Time.timeScale = 0f; //set the time scale to zero to stop most game functions, including physics
        gamePaused = true;
    }

    public void ReturnMain()
    {
        Resume();
        GameManager.Instance.LoadNewScene(GameManager.scenes.MAIN_MENU_SCENE);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
