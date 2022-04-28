using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHitscanBullet : Bullet
{
    public override void Fire(float range)
    {
        Debug.Log("Fire");
        RaycastHit hitInfo; //A raycasthit object to return the information about the raycast
        if (Physics.Raycast(fireTransform.position, fireTransform.forward, hitInfo: out hitInfo, maxDistance: range, layerMask: targets))
        {
            //a target was hit

            //Retrive the target, and put into array of size one for callback
            Entity[] targetHit = {hitInfo.collider.GetComponent<Entity>()};

            //Callback so the weapon can decide what to do
            OnHit(targetHit, null); //null since there is not AOE for indirect hit

        }
    }
}
