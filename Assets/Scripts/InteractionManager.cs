using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
   

public class InteractionManager : MonoBehaviour
{
    public GameObject[] InteractablesList;
    [SerializeField]
    public string[] InteractablesString;
    [SerializeField]
    public int InteractDistance = 5;
    private GameObject Player;
    private Camera Cam;
    private GameObject HitGameObject;
    public string Wincondition = "WinCon";
    private Collider WinTerminalCollider;
    private Collider BarrelWideCollider;
    private Collider BarrelStandardCollider;
    private Collider BarrelBoxCollider;
    private Collider BarrelTriCollider;
    private bool WideCheck;
    private bool StandardCheck;
    private bool BoxCheck;
    private bool TriCheck;


    [SerializeField]
    LayerMask InteractableLayer = 1 << 8;
    [SerializeField]
    LayerMask PlayerLayer = 1 << 3;
    



    private void Start()
    {
        Cam = Camera.main;
        Player = GameObject.FindGameObjectWithTag("PlayerMain");
        WinTerminalCollider = InteractablesList[8].GetComponent<MeshCollider>();
        BarrelWideCollider = InteractablesList[0].GetComponent<BoxCollider>();
        BarrelStandardCollider = InteractablesList[1].GetComponent<BoxCollider>();
        BarrelBoxCollider = InteractablesList[2].GetComponent<BoxCollider>();
        BarrelTriCollider = InteractablesList[3].GetComponent<BoxCollider>();
        WideCheck = false;
        StandardCheck = false;
        BoxCheck = false;
        TriCheck = false;
    }
    public void CheckForInteractable()
    {
        Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (BarrelWideCollider.Raycast(ray, out hit, InteractDistance))
        {
            Debug.Log("interact With Wide");
            InteractablesList[0].transform.position = InteractablesList[4].transform.position;
            WideCheck = true;
        }

        if (BarrelStandardCollider.Raycast(ray, out hit, InteractDistance))
        {
            Debug.Log("interact With Standard");
            InteractablesList[1].transform.position = InteractablesList[5].transform.position;
            StandardCheck = true;
        }
        if (BarrelBoxCollider.Raycast(ray, out hit, InteractDistance))
        {
            Debug.Log("interact With Box");
            InteractablesList[2].transform.position = InteractablesList[6].transform.position;
            BoxCheck = true;
        }
        if (BarrelTriCollider.Raycast(ray, out hit, InteractDistance))
        {
            Debug.Log("interact With Tri");
            InteractablesList[3].transform.position = InteractablesList[7].transform.position;
            TriCheck = true;
        }
        if (WinTerminalCollider.Raycast(ray, out hit, InteractDistance))
        {
            if (WideCheck & StandardCheck & BoxCheck & TriCheck)
            {
                EventManager.Instance.Notify(EventTypes.Events.GAME_VICTORY);
            }
        }


    }
     
}
