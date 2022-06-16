using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectDetection : MonoBehaviour
{
    public GameObject UI;

    void OnTriggerEnter(Collider Obj)
    {
        if (Obj.gameObject.layer == 8)
        {
            UI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider Obj)
    {
        if (Obj.gameObject.layer == 8)
        {
            {
                UI.SetActive(false);
            }
        }
    }
}
