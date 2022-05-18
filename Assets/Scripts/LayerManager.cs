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
    [SerializeField] LayerMask[] layers; //an array to store the value for each layer
                                         //setted in the inspector, ensure that the
                                         //inspector is in the same order of layerNames
    [SerializeField] LayerMask playersLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask winLayer;

    //By defualt the layer names will be the index
    //of the corresponding layer, ensure that layerNames
    //appear in the same order that they do in the inspector
    public enum layerNames
    {
        PLAYER,
        ENEMY,
        WIN
    }

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

    public LayerMask GetLayerMask(layerNames[] layersToMask)
    {
        LayerMask returnMask = 0; //the mask to be returned

        //create layer mask
        for (int layerIndex = 0; layerIndex < layersToMask.Length; layerIndex++)
        {
            returnMask = returnMask.value | layers[(int)layersToMask[layerIndex]].value;
        }

        //return the layer mask
        return returnMask;
    }

    public bool ObjectInLayerMask(GameObject gameObject, LayerMask mask)
    {
        //get the mask of the game object by shifting 1 left by gameObject.layer
        int gameObjectMask = 1 << gameObject.layer;

        //if the logical and produces 0 then the gameObject is not in mask
        //if the logical and produces anything else then the gameObject is in the mask
        return (gameObjectMask & mask) == 0;
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
    public LayerMask GetWinConLayer()
    {
        return winLayer;
    }
    
}
