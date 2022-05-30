using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    public List<InteractionManager> _list;
    [SerializeField]
    public int InteractDistance = 5;
    public Camera Cam;
    int layerMask = 1 << 9;

    private void Start()
    {
        Cam = Camera.main;

    }

    public void Interact()
    {
        if (Physics.Raycast(transform.position, new Vector3(Screen.width / 2, Screen.height / 2, 0), InteractDistance, layerMask))
        {

        }

    }
    


}
