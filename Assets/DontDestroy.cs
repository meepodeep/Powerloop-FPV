using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    [HideInInspector]
    public string objectID; 
    private void Awake()
    {
        objectID = name +transform.position.ToString();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
                {
                    
                    Destroy(gameObject); 
                }
            }
        }
      
       DontDestroyOnLoad(gameObject); 

    }
}
