using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class AudioManagerProps : MonoBehaviour
{
    float isThrottle;
    public Sound[] sounds;
    public Dronegozoomy dz;
    public AudioMixerGroup audioMixer; 
    const string propSound = "PropNoise";
    bool PropOn = false;  
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
            s.source.pitch = s.pitch; 
           
        }
    }


    // Update is called once per frame
    public void Play (string name)
    {
        //determines what sound is being called//
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        s.source.Play();
        //if the name of the sound that is currently playing is equal to the string propSound then PropOn=true else it is false//
        if (name == propSound)
            {
                PropOn = true; 
            }
            else 
            {
                PropOn = false; 
            }
    }
    
    void FixedUpdate()
    {   
        //if a sound is playing//
        foreach (Sound s in sounds)
        {
            //if PropOn is on//
            if (PropOn == true)
            {
                s.source.pitch = isThrottle;
            } else
            {
                s.source.pitch = s.pitch; 
            }
        }
        if (1 != dz.Power)
        {
            Mathf.Clamp(isThrottle -= .1f, .3f, 1);
        }
        isThrottle = Mathf.Clamp(isThrottle + dz.Power * Time.deltaTime, .3f, 1);
    }
}
