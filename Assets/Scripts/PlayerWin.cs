using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame

    public void returnToMenu()
    {
        EventManager.Instance.Notify(EventTypes.Events.PLAY_AGAIN);
    }

    public void Quit()
    {
        Application.Quit();

    }
}
