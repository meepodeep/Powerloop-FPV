using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class BatteryManager : MonoBehaviour
{
    public float charge = 10; 
    public float depletionRate = .5f; 
    public float [] LevelTime; 
    private int level = 0;
    // Update is called once per frame
    void Awake(){
        level = SceneManager.GetActiveScene().buildIndex; 
        LevelTime = new float[10];

        LevelTime[1] = .3f;
        LevelTime[2] = .5f;
        LevelTime[3] = .45f;
        LevelTime[4] = .4f;
        LevelTime[5] = .4f;
        LevelTime[6] = 0f;
        LevelTime[7] = .7f;
        LevelTime[8] = .8f;
        LevelTime[9] = .9f;
    }
    void FixedUpdate()
    {  if("tutorial" != SceneManager.GetActiveScene().name)
    {
        charge -= depletionRate * Time.deltaTime * LevelTime[level]; 
        if (charge <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadPrevLevel();
        }
    }
    
    }
}
