using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : Weapon
{
    // public override void PrimaryFire

    public override void HitTargetCallback(Entity[] directHit, IndirectHitInfo[] indirectHit)
    {
        //This gun is just dealing base damage
        directHit[0].health.TakeDamage(baseDamage);
    }
}
