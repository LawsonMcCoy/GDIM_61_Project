using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
   

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    public List<InteractionManager> _list;
    [SerializeField]
    public int InteractDistance = 5;
    private Camera Cam;
    [SerializeField]
    LayerMask layerMask = 1 << 9;

    private void Start()
    {
        Cam = Camera.main;

    }

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            if (Physics.Raycast(transform.position, new Vector3(Screen.width / 2, Screen.height / 2, 0), InteractDistance, layerMask))
            {

            }
        }
        

    }
    


}
