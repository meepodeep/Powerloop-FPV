using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class LevelManager : MonoBehaviour
{
    public GateManager gm; 
    private float [] Level; 
    // Start is called before the first frame update
    void Start()
    {
        Level = new float[11];

        Level[1] = 8;
        Level[2] = 10; 
        Level[3] = 15;
        Level[4] = 20;
        Level[5] = 24;
        Level[6] = 5;
    }

    // Update is called once per frame
    void Update()
    { 
                if("tutorial" == SceneManager.GetActiveScene().name && gm.comboCount == 5)
            {
                FindObjectOfType<LevelLoader>().LoadMainMenu();
            }
            if ((gm.comboCount == Level[SceneManager.GetActiveScene().buildIndex]) && ("tutorial" != SceneManager.GetActiveScene().name))
            {
                FindObjectOfType<LevelLoader>().LoadNextLevel();    
            }
    }
}
