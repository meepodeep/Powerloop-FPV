using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIndicator : MonoBehaviour
{
    float fill;
    [SerializeField] private Image ChargeIndicatorUI = null;
    public BatteryManager bm; 
    // Update is called once per frame
    void FixedUpdate()
    {
        ChargeIndicatorUI.fillAmount = fill;
        fill = bm.charge/10; 
    }
}
