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
    [SerializeField] protected float baseDamage;
    [SerializeField] protected float baseRange;
    

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


    //equipping the weapon in the game
    public void Equip()
    {
        //display the weapon
        gameObject.SetActive(true);
    }

    public void Unequip()
    {
        
    }

    public virtual void PrimaryFire()
    {
        primaryAmmo.Fire(baseRange);
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
