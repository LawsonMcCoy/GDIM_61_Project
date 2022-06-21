using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private Entity bossPrefab; //The prefab for the boss

    private void Start()
    {
        EventManager.Instance.Subscribe(EventTypes.Events.SPAWN_BOSS, SpawnTheBoss);
    }

    //Spawn the boss when the SPAWN_BOSS event is notified
    public void SpawnTheBoss()
    {
        Instantiate(bossPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }

    private void OnDestroy()
    {
        EventManager.Instance.Unsubscribe(EventTypes.Events.SPAWN_BOSS, SpawnTheBoss);
    }
}
