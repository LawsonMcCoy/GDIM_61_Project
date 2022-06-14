using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstantDamageEffect", menuName = "InstantDamageEffect")]
public class InstantDamage : WeaponEffect
{
    [SerializeField] private int damage;

    public override void ApplyEffect(Entity target)
    {
        //damage the target
        target.health.TakeDamage(damage);
    }
}
