using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : BehaviorBase
{
    private Player target; //A variable to store the player the enemy is attack, null when enemy is idle
    private WeaponStats equippedWeaponStats; //The weapon that the enemy will shoot the player with


    [SerializeField] private Entity enemy; //A reference to the enemies entity script
    //Scanning
    [SerializeField] private LayerMask playerLayer; //A layer mask for the player
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

    private void Start()
    {
        //get reference to the weapon
        equippedWeaponStats = enemy.equipped.GetWeaponStats();

        //Construct behavior tree
        // behavior
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
        Collider[] targets; //array of targets found by the scan

        targets = Physics.OverlapSphere(this.transform.position, scanRadius, playerLayer);

        //game is only single player right now, and probably forever
        //if targets is not null then set the target to the first element
        if (targets == null || targets.Length == 0)
        {
            target = null;
        }
        else
        {
            target = targets[0].gameObject.GetComponent<Player>();
        }
    }

    private void AttackTarget()
    {
        //sees the player, attack them
        if (Vector3.Distance(target.transform.position, this.transform.position) > equippedWeaponStats.range)
        {
            //player is out of range move in closer
            Follow(target.transform.position);
        }
        else
        {
            //player is in range, FIRE!!!
            ShootPlayer();
        }
    }

    private void ShootPlayer()
    {
        //Is there line of sight?
        Vector3 vectorToPlayer = target.transform.position - this.transform.position;
        if (Physics.Raycast(origin: this.transform.position, direction: vectorToPlayer, layerMask: playerLayer))
        {
            //has line of sight on player

            //look at player
            this.transform.LookAt(target.transform.position);

            //fire weapon
            enemy.equipped.PrimaryFire();
        }
        else
        {
            //Does not have line of sight, therefore needs to reposition to gain line of sight
            //To save time I am going to keep this simple and just move the enemy towards the player
            Follow(target.transform.position);
        }
    }
}
