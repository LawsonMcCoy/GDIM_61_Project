using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //the targets the bullet can hit
    protected LayerMask targets;
    protected Transform fireTransform; //a transform containing the posistion and rotation 
                                        //the bullet is fired with
    
    //A callback delegate to return infomation about the targets that were hit
    public delegate void HitCallback(Entity[] directHit, IndirectHitInfo[] indirectHit);
    public HitCallback OnHit
    {
        get;
        set;
    }  

    public abstract void Fire(float range, Transform fireTransform, LayerMask targets);

    public virtual void SetTargets(LayerMask targetsLayerMask)
    {
        targets = targetsLayerMask;
    }

    public void SetFireTransform(Transform fireTransform)
    {
        this.fireTransform = fireTransform;
    }
}
