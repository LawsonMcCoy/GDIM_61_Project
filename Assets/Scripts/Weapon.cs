using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //The indices for the primary and secondary firing states
    private const int PRIMARY_FIRE = 0;
    private const int SECONDARY_FIRE = 1;

    [Header("DO NOT modify the size of the arrays.")]
    [Header("Note: First index of arrays are for primary fire, second index are secondary fire.")]

    [SerializeField] protected Bullet[] ammo = new Bullet[2];
    [SerializeField] private bool hasSecondaryFire;
    [SerializeField] private AudioSource[] audio = new AudioSource[2];

    //Weapon effects
    [SerializeField] private List<WeaponEffect> directEffect; //effects applied to target that were hit directly
    [SerializeField] private List<WeaponEffect> indirectEffect; //effects applied to targets hit with AOE
    [SerializeField] private List<WeaponEffect> selfEffect; //effects applied to wielder if the weapon when target is hit
    

    private bool[] triggerHeld = new bool[2]; //booleans to keep track of when one of the triggers
                                              //is being held down (for automatic fire)

    private LayerMask targets; //A layerMask for the targetabstracts the gun can shoot

    //stats
    [SerializeField] protected int baseDamage;
    [SerializeField] protected float baseRange;
    [SerializeField] protected float fireRate; //time between shots
    [SerializeField] private int magazineSize = 10; //The total number of bullets the magazine can hold
    private int numberOfLoadedBullets; //The number of bullets left in the magazine
    [SerializeField] private float reloadTime; //The amount of the time it takes to reload the weapon

    private float timeOfCooldownExpiration; //The time the weapon will be ready to fire again

    //firing modes
    enum FiringMode
    {
        AUTOMATIC,
        SEMIAUTOMATIC
    };
    [SerializeField] private FiringMode[] firingMode = new FiringMode[2];
    
    private void Awake()
    {
        //Start the weapon off cooldown
        timeOfCooldownExpiration = 0f;

        //Start with a loaded magazine
        numberOfLoadedBullets = magazineSize;

        for (int fireIndex = 0; fireIndex < 2; fireIndex++) //2 is for primary and secondary fire
        {
            //initialize triggers to not being held down
            triggerHeld[fireIndex] = false;
        }
    }

    private void Start()
    {
        //Set up the bullets
        ammo[PRIMARY_FIRE].OnHit = HitTargetCallback;
        ammo[PRIMARY_FIRE].SetFireTransform(this.transform);
        ammo[PRIMARY_FIRE].SetTargets(targets);

        if (hasSecondaryFire)
        {
            ammo[SECONDARY_FIRE].OnHit = HitTargetCallback;
            ammo[SECONDARY_FIRE].SetFireTransform(this.transform);
            ammo[SECONDARY_FIRE].SetTargets(targets);
        } 
    }

    //A wrapper around the normal instantiate function
    //that will aid in setting up the weapon
    public static Weapon Instantiate(Weapon weaponPrefab, Transform entityTransform, Vector3 holdingPosition, Transform parentTransform, LayerMask targets)
    {
        Weapon instance = Instantiate(weaponPrefab, entityTransform.position + holdingPosition, entityTransform.rotation, parentTransform);

        instance.targets = targets;

        return instance;
    }

    private void Update()
    {
        for (int fireIndex = 0; fireIndex < 2; fireIndex++) //2 for primary and secondary
        {
            //if the trigger is being held down fire at the apporiate rate
            if (triggerHeld[fireIndex] && Time.time > timeOfCooldownExpiration)
            {
                Fire(fireIndex);
            }
        }
    }

    //equipping the weapon in the game
    public void Equip()
    {
        //display the weapon
        gameObject.SetActive(true);

        //friendly reminders
        if (baseRange == 0)
        {
            Debug.LogWarning("Base range of current weapon is 0");
        }

        if (baseDamage == 0)
        {
            Debug.LogWarning("Base damage of current weapon is 0");
        }
    }

    public void Unequip()
    {
        gameObject.SetActive(false);
    }

    //press primary trigger
    public virtual void PrimaryFire()
    {
        if (firingMode[PRIMARY_FIRE] == FiringMode.AUTOMATIC)
        {
            //If firing mode is automatic then fire the weapon in update until
            //the trigger is released
            triggerHeld[PRIMARY_FIRE] = true;
        }
        else //firingMode[PRIMARY_FIRE] = FiringMode.SEMIAUTOMATIC
        {
            //If firing mode is semi-automatic then fire the weapon once for each
            //time the trigger is pushed
            if (Time.time > timeOfCooldownExpiration)
            {
                Fire(PRIMARY_FIRE);
            }   
        }
    }

    //release primary trigger
    public void PrimaryRelease()
    {
        triggerHeld[PRIMARY_FIRE] = false;
    }

    //press secondary trigger
    public virtual void SecondaryFire()
    {
        //only do something if the weapon has a secondary fire
        if (hasSecondaryFire)
        {
            if (firingMode[SECONDARY_FIRE] == FiringMode.AUTOMATIC)
            {
                //If firing mode is automatic then fire the weapon in update until
                //the trigger is released
                triggerHeld[SECONDARY_FIRE] = true;
            }
            else //firingMode[SECONDARY_FIRE] = FiringMode.SEMIAUTOMATIC
            {
                //If firing mode is semi-automatic then fire the weapon once for each
                //time the trigger is pushed
                if (Time.time > timeOfCooldownExpiration)
                {
                    Fire(SECONDARY_FIRE);
                }   
            }//end else
        }//end if (hasSecondaryFire)
    }

    //release secondary trigger
    public void SecondaryRelease()
    {
        triggerHeld[SECONDARY_FIRE] = false;
    }

    private void Fire(int fireIndex)
    {
        if (numberOfLoadedBullets > 0) //there are bullets loaded
        {
            //fire a bullet
            if (Time.time > timeOfCooldownExpiration)
            {
                audio[fireIndex].Play();
                ammo[fireIndex].Fire(baseRange, transform, targets);

                //update cooldown time
                timeOfCooldownExpiration = Time.time + fireRate;

                //decrement the number of bullets loaded, since one was just fired
                numberOfLoadedBullets--;
            }   
        }
    }

    public void Reload()
    {
        //fill the magazine
        numberOfLoadedBullets = magazineSize;

        //add reload time to the cooldown
        timeOfCooldownExpiration = Time.time + reloadTime;
    }

    //A small getter function for checking the number of bullets currently loaded in the magazine
    public int CheckMagazine()
    {
        return numberOfLoadedBullets;
    }

    //The callback when the bullet hit a target
    public void HitTargetCallback(Entity[] directHit, IndirectHitInfo[] indirectHit)
    {
        //Applies direct effects 
        for (int hitIndex = 0; hitIndex < directHit.Length; hitIndex++)
        {
            for (int effectIndex = 0; effectIndex < directEffect.Count; effectIndex++)
            {
                directEffect[effectIndex].ApplyEffect(directHit[hitIndex]);
            }
        }

        //Applies indirect effects 
        for (int hitIndex = 0; hitIndex < indirectHit.Length; hitIndex++)
        {
            for (int effectIndex = 0; effectIndex < indirectEffect.Count; effectIndex++)
            {
                indirectEffect[effectIndex].ApplyEffect(indirectHit[hitIndex].targetHit);
            }
        }

        //For later, implement code to apply self effect
    }
    public void SetTargets(LayerMask targets)
    {
        this.targets = targets;
    }

    public WeaponStats GetWeaponStats()
    {
        WeaponStats returnValue = new WeaponStats();

        returnValue.damage = baseDamage;
        returnValue.range = baseRange;
        returnValue.rateOfFire = fireRate;
    
        return returnValue;
    }
}

public struct IndirectHitInfo
{
    public Entity targetHit; //The the target that was hit indirectly
    public float distanceFromHit; //The distance between the target and the actual hit point
}

public struct WeaponStats
{
    public int damage;
    public float range;
    public float rateOfFire;
}