using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedModifierEffect", menuName = "SpeedModifierEffect")]
public class SpeedModifierEffect : WeaponEffect
{
    [SerializeField] private float speedModifier; //modifier to target's speed as a percentage
    [SerializeField] private float timeModified; //The amount of time the effect last for

    public override void ApplyEffect(Entity target)
    {
        //Apply the speed modifier to the target
        target.ModifySpeed(speedModifier, timeModified);
    }
}
