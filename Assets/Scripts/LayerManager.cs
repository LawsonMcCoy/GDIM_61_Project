using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will be used to return bit strings for different layers
//The strength here is that the class act as a layer of abstract between
//our code and Unity's layer system. This will allow us to create "layers"
//that are just a combination of Unity layers. For example in Unity we may
//have the layer interactable object, and static object. This class will provide
//a function to get a bit string mask for each of those, but also a third function
//to get a bit string mask for a "layer" called environment, which just masks both of
//those layers. Please note that this class is a complete experiment, I don't know if
//it will work well, but if it does it could make our lives a lot easier.
public class LayerManager : MonoBehaviour
{
    //The layers in Unity
    [SerializeField] LayerMask playersLayer;
    [SerializeField] LayerMask enemyLayer;

    //This class is a singleton
    public static LayerManager Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        //set up singleton
        Instance = this;

        //enforces singleton
        DontDestroyOnLoad(this);
    }

    public LayerMask GetPlayerLayerMask()
    {
        return playersLayer;
    }

    public LayerMask GetEnemyLayer()
    {
        return enemyLayer;
    }

    //Player or enemy
    public LayerMask GetEntityLayer()
    {
        LayerMask layerValue = playersLayer.value | enemyLayer.value;

        return layerValue;
    }
    
}
