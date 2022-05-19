using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOverMenu;

    
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   
    

    public void Restart()
    {
        EventManager.Instance.Notify(EventTypes.Events.RESTART);

    }

    public void Quit()
    {
        Application.Quit();

    }
}
