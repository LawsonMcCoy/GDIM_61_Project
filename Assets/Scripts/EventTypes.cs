using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTypes : MonoBehaviour
{
    public enum Events { 
        PLAYER_DEATH,
        GAME_VICTORY,
        GAME_PAUSE,
        GAME_UNPAUSE

    };
}
