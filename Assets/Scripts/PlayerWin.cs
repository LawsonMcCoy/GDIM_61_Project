using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWin : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void returnToMenu()
    {
        GameManager.Instance.LoadNewScene(GameManager.scenes.MAIN_MENU_SCENE);
    }

    public void Quit()
    {
        Application.Quit();

    }
}
