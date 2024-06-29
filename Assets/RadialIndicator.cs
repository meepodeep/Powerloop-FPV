using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RadialIndicator : MonoBehaviour
{
    public GateManager gm;
    public Dronegozoomy dz;
    [HideInInspector] public float gateTrigger;

    [SerializeField] private Image radialIndicatorUI = null;
    public float fill;
    float comboFill;
      
      private void Update()
      {
        if (gm.comboCount == 0)
        {
          fill = 0;
        }
        else
        {
          comboFill = -.25f * gm.comboTime + 1f;
        }
        
        fill = comboFill;
        radialIndicatorUI.fillAmount = fill;
      }
}

