using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(HealthManager))] for later
public class Entity : MonoBehaviour
{
    [SerializeField] protected LayerMask targetsToDamage; //A layer mask of targets to damage

//    [SerializeField] private HealthManager healthManagerInspector; for later
//    public HealthManager healthManager
//    {
//        get { return healthManagerInspector };
//        private set { healthManagerInspector = value };
//    }

}
