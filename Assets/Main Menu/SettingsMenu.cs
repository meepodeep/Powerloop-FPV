using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{   public Slider VolumeSlider;
    public Slider SensSlider;
    public Toggle FullscreenToggle;
    public static float RollSensitivity = 400; 
    public AudioMixer audioMixer; 
    public MainMenu mm;  
    void Awake()
    {
        LoadPlayer();
    }
    void Update()
    {
        Screen.fullScreen = FullscreenToggle.isOn;
        RollSensitivity = SensSlider.value;
        audioMixer.SetFloat("volume",VolumeSlider.value);
    }
   public void Saveplayer()
   {
     SaveSystem.SavePlayer(this); 
   }
   public void LoadPlayer()
   {
     Debug.Log("exists"); 
        string path = Application.persistentDataPath + "/player.zoom"; 
        if (File.Exists(path))
        {
            PlayerData data = SaveSystem.LoadPlayer(); 
            VolumeSlider.value = data.volumeData; 
            SensSlider.value = data.Sensitivity;
            FullscreenToggle.isOn = data.IsFullscreen;
           
        } else
        {
            Saveplayer();
        }
   }
}
