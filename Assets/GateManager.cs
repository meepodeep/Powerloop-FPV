using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateManager : MonoBehaviour
{
    public float comboCount;
    public float comboTime;
    public Text comboText;
    public Dronegozoomy dz;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (comboTime >= 4)
        {
            comboTime = comboTime - comboTime;
            comboCount = 0;
        }

        comboText.text = comboCount.ToString();
         
    }
}
