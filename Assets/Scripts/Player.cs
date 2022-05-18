using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{    
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

    
}
