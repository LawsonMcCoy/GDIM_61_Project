using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private Text volumeTextUI = null;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", 1);
        }
        else
        {
            LoadValues();

        }
    }

    public void VolumeSlider(float vol)
    {
        volumeTextUI.text = vol.ToString("0.0");
    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
