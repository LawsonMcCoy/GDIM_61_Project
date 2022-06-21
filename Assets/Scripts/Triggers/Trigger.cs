using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a simple trigger script that will fire an event using the
//event system when the player collides with the attached game object
public class Trigger : MonoBehaviour
{
    [SerializeField] private EventTypes.Events triggerEvent;

    private void OnTriggerEnter()
    {
        Debug.Log("Trigger");
        EventManager.Instance.Notify(triggerEvent);
    }
}
