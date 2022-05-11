using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GenericHealth
{

    protected override void onDeath()
    {
        Destroy(this.gameObject);
    }

}
