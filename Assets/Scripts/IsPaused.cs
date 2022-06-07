using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPaused : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_PAUSE, ifPaused);
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_UNPAUSE, ifUnpaused);
    }


    void ifPaused()
    {
        gameObject.SetActive(false);
    }

    void ifUnpaused()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_PAUSE, ifPaused);
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_UNPAUSE, ifUnpaused);
    }
}
