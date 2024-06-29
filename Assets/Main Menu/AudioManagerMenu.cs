using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class AudioManagerMenu : MonoBehaviour
{
    float isThrottle;
    public Sound[] sounds;
    public MainMenu mu; 
    public AudioMixerGroup audioMixer; 
    // Start is called before the first frame update
    void Awake ()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = audioMixer;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            
           
        }
    }


    // Update is called once per frame
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
}
