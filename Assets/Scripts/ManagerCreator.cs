using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCreator : MonoBehaviour
{
    //The list of prefabs for the managers
    [SerializeField] private List<GameObject> managerPrefabs;
    private static bool alreadyCreatedManagers = false;

    private void Awake()
    {
        //If the managers have not been created yet, create them
        if (!alreadyCreatedManagers)
        {
            foreach (GameObject manager in managerPrefabs)
            {
                Instantiate(manager);
            }

            //mark managers as created
            alreadyCreatedManagers = true;
        }
    }

}
