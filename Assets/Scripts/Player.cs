using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{    
    [SerializeField] private PlayerInput input;
    [SerializeField] private MovementScript movement;

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
