using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitscanBullet : BasicHitscanBullet
{
    private Camera playerCamera; //The player's camera
    private Vector3 crosshairsPosition; //The location of the crosshairs on the screen
    private Ray test;

    public override void SetTargets(LayerMask targetsLayerMask)
    {
        //get a reference to the player's camera
        playerCamera = Camera.main;

        //get the midpoint of the screen by computing half the width and height of the screen (set z to 0 so there is no depth)
        crosshairsPosition = new Vector3(playerCamera.pixelWidth/2, playerCamera.pixelHeight/2, 0);

        base.SetTargets(targetsLayerMask);
    }


    public override void Fire(float range, Transform fireTransform, LayerMask targets)
    {
        RaycastHit hitInfo; //A raycasthit object to return the information about the raycast
        Ray bulletRay = playerCamera.ScreenPointToRay(crosshairsPosition);
        PlayerHitscanBullet testObject = Instantiate(this);
        testObject.test = bulletRay;
        if (Physics.Raycast(bulletRay, hitInfo: out hitInfo, maxDistance: range, layerMask: targets))
        {
            //a target was hit

            //Retrive the target, and put into array of size one for callback
            Entity[] targetHit = {hitInfo.collider.GetComponent<Entity>()};

            //Callback so the weapon can decide what to do
            OnHit(targetHit, null); //null since there is not AOE for indirect hit
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(test);
    }
}
