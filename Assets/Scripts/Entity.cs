using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GenericHealth))] 
public class Entity : MonoBehaviour
{
    [SerializeField] protected LayerMask targetsToDamage; //A layer mask of targets to damage
    [SerializeField] Vector3 weaponPosition; //where the weapon being held is relative to the entity 

    //stats
    [SerializeField] protected float speed;
    private int speedModifierCount; //A simple counter for speed modifiers, used to know when to reset the speed

    [SerializeField] private Weapon startingWeapon;
    public Weapon equipped
    {
        get;
        set;
    }

    [SerializeField] private GenericHealth healthManagerInspector; 
    public GenericHealth health
    {
        get { return healthManagerInspector; }
        private set { healthManagerInspector = value; }
    }

    //A reference to the child game object that will rotate when the entity looks around
    //Things like weapons will need to be a child of this game object
    [SerializeField] GameObject lookAtRig;
    public GameObject lookDirection
    {
        get {return lookAtRig;}
        protected set {lookAtRig = lookDirection;}
    }

    protected virtual void Awake()
    {
        //Create starting weapon
        equipped = Weapon.Instantiate(startingWeapon, this.transform, weaponPosition, lookDirection.transform, targetsToDamage);

        equipped.Equip();
    }

    protected virtual void Start()
    {
        InitializeStats();
    }

    //A function called in start to initialize stats of the enitity
    //this will be cleaner if entity was an abstract class, this will then
    //be an abstract function. 
    protected virtual void InitializeStats()
    { 
        NavMeshAgent agent = this.GetComponent<NavMeshAgent>(); //get the navmesh agent
        agent.speed = this.speed; //initialize speed
    }

    public virtual void ModifySpeed(float speedModifier, float timeModified=0.0f)
    {
        //player will override this function, so this can assume that there is a nagmesh agent
        //Note that this will be cleaner if we create an enemy (or AIEntity) script that also
        //inherits from entity, and make navmesh agent a required component of that script

        NavMeshAgent agent = this.GetComponent<NavMeshAgent>(); //get the navmesh agent

        agent.speed = this.speed * speedModifier;

        //if the modifier does not place the speed at the normal speed, set a expiration timer
        if (speedModifier != 1.0f) //1.0 is 100% of the normal speed
        {
            StartCoroutine(StartSpeedResetTimer(timeModified));
        }
    }

    protected IEnumerator StartSpeedResetTimer(float timeModified)
    {
        //add this effect to the counter
        speedModifierCount++;

        //pause for the apporiate amount of time
        yield return new WaitForSeconds(timeModified);

        //decrement the counter now that the effect has ended
        speedModifierCount--;

        //if no active effect then reset the speed
        if (speedModifierCount == 0)
        {
            //use 1.0 for 100% of the normal speed
            ModifySpeed(1.0f);
        }
    }
}
