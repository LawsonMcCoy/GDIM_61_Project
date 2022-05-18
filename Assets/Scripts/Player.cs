using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float ActiveDistance = 5.0f;
    public string playerTag = "Player";
    public string Wincondition = "WinCon";
    public GameObject player;
    private Camera Cam;
    private Collider WinCollider;
    private GameObject WinTerminal;
    // Start is called before the first frame update
    public PlayerHealth playerHealth;


    private void Start()
    {
        Cam = Camera.main;
        WinTerminal = GameObject.FindGameObjectWithTag(Wincondition);
        WinCollider = WinTerminal.GetComponent<CapsuleCollider>();
    }

    private void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.LogWarning("check for interact input");
            TryTerminal();
        }

    }
    void TryTerminal()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, WinTerminal.transform.position)) <= ActiveDistance)
        {

            Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (WinCollider.Raycast(ray, out hit, ActiveDistance))
            {

                EventManager.Instance.Notify(EventTypes.Events.GAME_VICTORY);
                SceneManager.LoadScene("Win!");
                //Debug.LogWarning(transform.position - Player.transform.position);

            }
            Debug.LogWarning((transform.position - WinTerminal.transform.position).magnitude);

        }

    }
    // Update is called once per frame
    private void Update()
    {

    }

    
}
