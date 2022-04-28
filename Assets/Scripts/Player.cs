using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        //Create starting weapon
        equipped = Instantiate(startingWeapon, this.transform.position + weaponPosition, this.transform.rotation, this.transform);
        equipped.SetTargets(targetsToDamage);

        equipped.Equip();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButtons.LEFT_CLICK))
        {
            equipped.PrimaryFire();
        }
    }
}
