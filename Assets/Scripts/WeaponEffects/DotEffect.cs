using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DotEffect", menuName = "DotEffect")]
public class DotEffect : WeaponEffect
{
    [SerializeField] private int damagePerTick; //The amount of damage to be substained each tick
    [SerializeField] private float timeOfTick; //The amount of time between each tick of damage
    [SerializeField] private float totalExpirationTime; //The amount of time the dot lasts for
    private Entity DotTarget;

    public override void ApplyEffect(Entity target)
    {
        //set the target
        DotTarget = target;

        //begin the dot
        WeaponEffectHelper.Instance.StartCoroutine(DotTick());
    }

    private IEnumerator DotTick()
    {
        //Calculate the expiration time of the dot
        float dotExpirationTime = Time.time + totalExpirationTime;

        //Loop until the dot expires, or target dies
        //each iteration is one tick
        while(Time.time < dotExpirationTime && DotTarget != null)
        {
            //deal damage
            DotTarget.health.TakeDamage(damagePerTick);

            //pause until iteration is complete
            yield return new WaitForSeconds(timeOfTick);
        }
    }
}
