using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        //set the cam to be the main camera (the camera the player is using)
        cam = Camera.main.transform;
    }
    
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
