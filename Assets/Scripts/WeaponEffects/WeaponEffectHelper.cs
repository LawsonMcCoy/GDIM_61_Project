using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is to provide the weapon effects (which are scriptable objects) with some
//monobehavior functionality, such as coroutines
public class WeaponEffectHelper : MonoBehaviour
{
    //Is a singleton
    public static WeaponEffectHelper Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        //Set up singleton
        Instance = this;
    }

    private void OnDestroy()
    {
        //mark singleton as destoryed
        Instance = null;
    }
}
