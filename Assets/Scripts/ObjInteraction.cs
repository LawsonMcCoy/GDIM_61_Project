using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;

    public GameObject UICross;

    void OnTriggerEnter(Collider Obj)
    {
        if (Obj.tag == "Interactable")
        {
            UI.SetActive(true);
            UICross.SetActive(false);
            Debug.Log("collision");
        }
    }

    void OnTriggerExit(Collider Obj)
    {
        if (Obj.tag == "Interactable")
        {
            {
                UI.SetActive(false);
                UICross.SetActive(true);
            }
        }
    }
}