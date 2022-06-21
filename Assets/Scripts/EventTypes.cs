using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTypes : MonoBehaviour
{
    public enum Events { 
        PLAYER_DEATH,
        GAME_VICTORY,
        RESTART,
        PLAY_AGAIN,
        GAME_PAUSE,
        GAME_UNPAUSE,
        SPAWN_BOSS

    };
}
