using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    public float ActiveDistance = 5.0f;
    public string playerTag = "Player";
    public string Wincondition = "WinCon";
    private Camera Cam;
    private Collider WinCollider;
    private GameObject WinTerminal;
    // Start is called before the first frame update
    public PlayerHealth playerHealth;
    [SerializeField] private PlayerInput input;
    [SerializeField] private MovementScript movement;
    [SerializeField] private InteractionManager InteractionManager;


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
            TryInteract();
        }
    }

    protected override void Awake()
    {
        base.Awake();

        // subscribes to pause and unpause events to disable and enable input
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_PAUSE, DisableInput);
        EventManager.Instance.Subscribe(EventTypes.Events.GAME_UNPAUSE, EnableInput);
    }

    public void DisableInput()
    {
        input.enabled = false;

        //also disable the player's movement
        movement.enabled = false;
    }

    public void EnableInput()
    {
        input.enabled = true;

        //also enable the player's movement
        movement.enabled = true;
    }

    private void OnPrimaryFire(InputValue value)
    {
        if (value.isPressed)
        {
            equipped.PrimaryFire();
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
            }
            Debug.LogWarning((transform.position - WinTerminal.transform.position).magnitude);

        }

    }

    void TryInteract()
    {
        InteractionManager.Interact();
    }

    private void OnSecondaryFire(InputValue value)
    {
        if (value.isPressed)
        {
            equipped.SecondaryFire();
        }           
    }

    private void OnDestroy()
    {
        //unsubscribe for events
        EventManager.Instance.Unsubscribe(EventTypes.Events.GAME_PAUSE, DisableInput);
        EventManager.Instance.Unsubscribe(EventTypes.Events.GAME_UNPAUSE, EnableInput);
    }

    
}
