using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [SerializeField] Vector3 weaponPosition; //where the weapon being held is relative to the entity 
    enum MouseButtons
    {
        LEFT_CLICK,
        RIGHT_CLICK,
        MIDDLE_CLICK
    }

    [SerializeField] private Weapon startingWeapon;
    private Weapon equipped;

    // Start is called before the first frame update
    public PlayerHealth playerHealth;


    private void Start()
    {
        //Create starting weapon
        equipped = Instantiate(startingWeapon, this.transform.position + weaponPosition, this.transform.rotation, this.transform);
        equipped.SetTargets(targetsToDamage);

        equipped.Equip();
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

    
}
