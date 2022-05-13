using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BasicProjectileBullet : Bullet
{
    [SerializeField] private float projectileSpeed;
    private float range;

    private void LaunchProjectile(float range)
    {
        Rigidbody projectileRigidbody; //a reference to the projectile's rigidbody

        //set the range
        this.range = range;

        //apply force to the projectile
        projectileRigidbody = GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(projectileSpeed * this.transform.forward, ForceMode.VelocityChange);

        //destroy projectile after traveling its max distance
        StartCoroutine(DespawnFromTime());
    }

    private IEnumerator DespawnFromTime()
    {
        if (projectileSpeed == 0)
        {
            Debug.LogError("Don't forget to set the projectile's speed");
        }

        Debug.Log($"Projectile created for {range/projectileSpeed} seconds");
        Debug.Log($"range: {range}, speed: {projectileSpeed}");

        //distance divided by speed is time
        yield return new WaitForSeconds(range/projectileSpeed);

        Destroy(this.gameObject);
    }  

    public override void Fire(float range)
    {
        BasicProjectileBullet projectile; //a reference to the projectile

        //Friendly reminders
        if (projectileSpeed == 0)
        {
            Debug.LogError("Don't forget to set the projectile's speed");
        }

        if (range == 0)
        {
            Debug.LogError("Don't forget to set the projectile's range");
        }

        //Instantiate projectile
        projectile = Instantiate(this, fireTransform.position, fireTransform.rotation);

        //Set up the projectile's targets and callback
        projectile.SetTargets(targets);
        projectile.OnHit = this.OnHit;
        
        //launch the projectile
        projectile.LaunchProjectile(range);
    }

    private void OnTriggerEnter(Collider collidedWith)
    {
        //Check the mask to make sure the collider is a target
        if (LayerManager.Instance.ObjectInLayerMask(collidedWith.gameObject, targets))
        {
            //a target was hit

            //Retrive the target, and put into array of size one for callback
            Entity[] targetHit = {collidedWith.GetComponent<Entity>()};

            //Callback so the weapon can decide what to do
            OnHit(targetHit, null); //null since there is not AOE for indirect hit
        }
    }
}
