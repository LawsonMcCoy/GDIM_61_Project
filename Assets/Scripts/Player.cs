using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    public float InteractDistance = 5.0f;
    public string playerTag = "Player";
    public string Wincondition = "WinCon";
    public string EventSystemTag = "EventSystem";
    private Camera Cam;
    private Collider WinCollider;
    private GameObject WinTerminal;
    private GameObject Eventsystem;
    InteractionManager interactionManager;
    // Start is called before the first frame update
    public PlayerHealth playerHealth;
    [SerializeField] private PlayerInput input;
    [SerializeField] private MovementScript movement;
    [SerializeField] LayerMask InteractableLayer = 1 << 9;


    private void Start()
    {
        Cam = Camera.main;
        WinTerminal = GameObject.FindGameObjectWithTag(Wincondition);
        Eventsystem = GameObject.FindGameObjectWithTag(EventSystemTag);
        WinCollider = WinTerminal.GetComponent<CapsuleCollider>();
        interactionManager = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<InteractionManager>();
    }

    private void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.LogWarning("check for interact input");
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
        Debug.Log("Primary Fire");
        if (value.isPressed)
        {
            equipped.PrimaryFire();
        }
        else
        {
            Debug.Log("Release");
            equipped.PrimaryRelease();
        }
    }
    
    void TryInteract()
    {
        interactionManager.CheckForInteractable();  
       
    }


    private void OnSecondaryFire(InputValue value)
    {
        if (value.isPressed)
        {
            equipped.SecondaryFire();
        }    
        else
        {
            equipped.SecondaryRelease();
        }       
    }

    private void OnDestroy()
    {
        //unsubscribe for events
        EventManager.Instance.Unsubscribe(EventTypes.Events.GAME_PAUSE, DisableInput);
        EventManager.Instance.Unsubscribe(EventTypes.Events.GAME_UNPAUSE, EnableInput);
    }

    
}
