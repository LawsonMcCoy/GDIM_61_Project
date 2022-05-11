using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver : MonoBehaviour
{
    [SerializeField] private LayerMask targets;

    private void OnTriggerEnter(Collider other)
    {
        if (LayerManager.Instance.ObjectInLayerMask(other.gameObject, targets))
        {
            
        }
    }
}
