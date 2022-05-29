using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GenericHealth))] 
public class Entity : MonoBehaviour
{
    [SerializeField] protected LayerMask targetsToDamage; //A layer mask of targets to damage
    [SerializeField] Vector3 weaponPosition; //where the weapon being held is relative to the entity 

    [SerializeField] private Weapon startingWeapon;
    public Weapon equipped
    {
        get;
        set;
    }

    [SerializeField] private GenericHealth healthManagerInspector; 
    public GenericHealth health
    {
        get { return healthManagerInspector; }
        private set { healthManagerInspector = value; }
    }

    //A reference to the child game object that will rotate when the entity looks around
    //Things like weapons will need to be a child of this game object
    [SerializeField] GameObject lookAtRig;
    public GameObject lookDirection
    {
        get {return lookAtRig;}
        protected set {lookAtRig = lookDirection;}
    }

    protected virtual void Awake()
    {
        //Create starting weapon
        equipped = Weapon.Instantiate(startingWeapon, this.transform, weaponPosition, lookDirection.transform, targetsToDamage);

        equipped.Equip();
    }
}
