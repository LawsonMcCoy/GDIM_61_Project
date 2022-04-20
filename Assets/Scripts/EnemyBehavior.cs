using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : BehaviorBase
{
    Player target; //A variable to store the player the enemy is attack, null when enemy is idle

    //Scanning
    [SerializeField] private float scanRadius; //Radius of the scan
    [SerializeField] private float timeBetweenScans; //the amount of the time that passes before the next scan
    private float timeSinceLastScan; //The amount of the time since the last scan

    private void Awake()
    {
        //initialize target to null
        target = null;

        //initialize time since last scan to 0
        timeSinceLastScan = 0.0f;
    }

    //Later I will replace this with a behavior tree, for now we don't need that
    protected override void PerformBehavior()
    {
        //check if time for scan
        timeSinceLastScan += Time.deltaTime;
        if (timeSinceLastScan >= timeBetweenScans)
        {
            //time to scan for player
            ScanForTargets();
        }
        
        //if there is a target, attack it
        if (target != null)
        {
            AttackTarget();
        }
        else
        {
            agent.SetDestination(gameObject.transform.position);
        }
    }

    //Use Physic.OverlapSphere to scan for players
    void ScanForTargets()
    {
        LayerMask playerLayer = LayerManager.Instance.GetPlayerLayerMask();
        Collider[] targets; //array of targets found by the scan

        Debug.Log($"Mask: {playerLayer.value}");
        targets = Physics.OverlapSphere(this.transform.position, scanRadius, playerLayer);

        //game is only single player right now, and probably forever
        //if targets is not null then set the target to the first element
        if (targets == null || targets.Length == 0)
        {
            Debug.Log("No target");
            target = null;
        }
        else
        {
            Debug.Log("Found a target");
            target = targets[0].gameObject.GetComponent<Player>();
        }
    }

    void AttackTarget()
    {
        Follow(target.transform.position);
    }
}
