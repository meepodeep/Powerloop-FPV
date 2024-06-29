using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{ 
    public float volumeData;
    public float Sensitivity; 
    public bool IsFullscreen; 
    public PlayerData (SettingsMenu settingsMenu)
    {
        volumeData = settingsMenu.VolumeSlider.value; 
        Sensitivity = settingsMenu.SensSlider.value; 
        IsFullscreen = settingsMenu.FullscreenToggle.isOn;
    }
}
