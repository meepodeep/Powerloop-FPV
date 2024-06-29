using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDampening : MonoBehaviour
{
    public Dronegozoomy dz; 
    // Update is called once per frame
    void Update()
    {
        if (dz.water == .5f)
        {
            GetComponent<AudioLowPassFilter>().cutoffFrequency = 1000;
        } else 
        {
            GetComponent<AudioLowPassFilter>().cutoffFrequency = 2200000;
        }
         
    }
}
