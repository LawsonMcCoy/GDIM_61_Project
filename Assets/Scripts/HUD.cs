using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider slider; //The health bar for the player
    public static HUD Instance
    {
        get;
        private set;
    }


    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public Slider getSlider()
    {
        return this.slider;
    }
}
