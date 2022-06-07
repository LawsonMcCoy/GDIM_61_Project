using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider slider; //The health bar for the player
    [SerializeField] private Image damageImage;
    [SerializeField] protected float damageFlashSpeed = 3f;
    [SerializeField] protected Color damageFlashColor = new Color(1f, 0f, 0f, 0.1f);


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

    public Image getImage()
    {
        return this.damageImage;

    }

    public float getFloat()
    {
        return this.damageFlashSpeed;

    }

    public Color getColor()
    {
        return this.damageFlashColor;

    }



}
