using System.Collections.Generic;
using UnityEngine;
using System;

//A note from Lawson
//This script was pulled from my GDIM 161 project. It was originally written by Kevin Chao from
//that group. Before using this script for this project I got Kevin's and everyone in this group 
//expressed permission. 

// Singleton
public class EventManager : MonoBehaviour
{
    private static Dictionary<EventTypes.Events, Action> subscriberDict;

    public static EventManager Instance
    {
        get;
        private set;
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            subscriberDict = new Dictionary<EventTypes.Events, Action>();

            DontDestroyOnLoad(gameObject);
        }
    }


    private void OnDestroy()
    {
        // Instance = null;
    }


    public void Subscribe(EventTypes.Events eventType, Action listener)
    {
        Action existingListeners;

        // If eventType has listeners already in subscriberDict
        if (subscriberDict.TryGetValue(eventType, out existingListeners))
        {
            // Add new listener to existingListeners
            existingListeners += listener;

            // Update subscriberDict
            subscriberDict[eventType] = existingListeners;
        }

        // If eventType has no listeners in subscriberDict
        else
        {
            // Add event to subscriberDict
            existingListeners += listener;
            subscriberDict.Add(eventType, existingListeners);
        }
    }


    public void Unsubscribe(EventTypes.Events eventType, Action listener)
    {
        // If EventManager is already destroyed, no reason to unsubscribe
        if (Instance == null) return;

        Action existingListeners;

        // If eventType has listeners already in subscriberDict
        if (subscriberDict.TryGetValue(eventType, out existingListeners))
        {
            // Remove listener from existingListeners
            existingListeners -= listener;

            // Update subscriberDict
            subscriberDict[eventType] = existingListeners;
        }
    }


    public void Notify(EventTypes.Events eventType)
    {
        // If eventType is in the subscriberDict, invoke all listeners of that eventType
        Action existingListeners = null;
        if (subscriberDict.TryGetValue(eventType, out existingListeners))
            existingListeners.Invoke();
    }
}

