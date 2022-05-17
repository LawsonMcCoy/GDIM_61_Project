using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet primaryAmmo;
    [SerializeField] private bool hasSecondaryFire;
    [SerializeField] protected Bullet secondaryAmmo;

    private LayerMask targets; //A layerMask for the targets the gun can shoot

    //stats
    [SerializeField] protected int baseDamage;
    [SerializeField] protected float baseRange;
    [SerializeField] protected float fireRate; //time between shots

    private float timeOfCooldownExpiration; //The time the weapon will be ready to fire again

    //firing modes
    enum FiringMode
    {
        AUTOMATIC,
        SEMIAUTOMATIC
    };
    [SerializeField] private FiringMode primaryFiringMode;
    [SerializeField] private FiringMode secondaryFiringMode; 
    
    private void Awake()
    {
        //Start the weapon off cooldown
        timeOfCooldownExpiration = 0f;
    }

    private void Start()
    {
        //Set up the bullets
        primaryAmmo.OnHit += HitTargetCallback;
        primaryAmmo.SetFireTransform(this.transform);
        primaryAmmo.SetTargets(targets);

        if (hasSecondaryFire)
        {
            secondaryAmmo.OnHit += HitTargetCallback;
            secondaryAmmo.SetFireTransform(this.transform);
            secondaryAmmo.SetTargets(targets);
        } 
    }

    //A wrapper around the normal instantiate function
    //that will aid in setting up the weapon
    // public Weapon Instantiate(Weapon weaponPrefab, Transform entityTransform, Vector3 holdingPosition)

    //equipping the weapon in the game
    public void Equip()
    {
        //display the weapon
        gameObject.SetActive(true);

        //friendly reminders
        if (baseRange == 0)
        {
            Debug.LogWarning("Base range of current weapon is 0");
        }

        if (baseDamage == 0)
        {
            Debug.LogWarning("Base damage of current weapon is 0");
        }
    }

    public void Unequip()
    {
        gameObject.SetActive(false);
    }

    public virtual void PrimaryFire()
    {
        if (Time.time > timeOfCooldownExpiration)
        {
            primaryAmmo.Fire(baseRange);

            //update cooldown time
            timeOfCooldownExpiration = Time.time + fireRate;
        }
    }

    public virtual void SecondaryFire()
    {
        if (hasSecondaryFire && Time.time > timeOfCooldownExpiration)
        {
            secondaryAmmo.Fire(baseRange);

            //update cooldown time
            timeOfCooldownExpiration = Time.time + fireRate;
        }
    }

    public abstract void HitTargetCallback(Entity[] directHit, IndirectHitInfo[] indierctHit);

    public void SetTargets(LayerMask targets)
    {
        this.targets = targets;
    }
}

public struct IndirectHitInfo
{
    Entity targetHit; //The the target that was hit indirectly
    float distanceFromHit; //The distance between the target and the actual hit point
}