using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton : MonoBehaviour
{
    //Reference to the singleton instance
    public static Singleton Instance
    {
        get;
        private set;
    }

    protected void Awake()
    {
        //set the Instance property 
        Instance = this;

        //Don't destroy the Singleton when loading a new scene
        //enforces the singleton property
        DontDestroyOnLoad(this);
    }
}
