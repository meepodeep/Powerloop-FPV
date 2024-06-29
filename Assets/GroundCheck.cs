using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float isground;
    void OnTriggerEnter2D(Collider2D col)
     {
        if(col.gameObject.CompareTag("Floor")){
            isground = 1f; 
            Debug.Log("floor");
        }
     }
     void OnTriggerExit2D(Collider2D col)
     {
        if(col.gameObject.CompareTag("Floor")){
            isground = 0f; 
        }
     }
}
