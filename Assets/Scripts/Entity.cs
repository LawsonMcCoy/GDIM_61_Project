using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GenericHealth))] 
public class Entity : MonoBehaviour
{
    [SerializeField] protected LayerMask targetsToDamage; //A layer mask of targets to damage

    [SerializeField] private GenericHealth healthManagerInspector; 
    public GenericHealth health
    {
        get { return healthManagerInspector; }
        private set { healthManagerInspector = value; }
    }

}
