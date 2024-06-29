using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = .9f;  
    public Animator transition;
    
    // Update is called once per frame
  

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1 ));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); 

        yield return new WaitForSeconds(transitionTime); 

        SceneManager.LoadScene(levelIndex); 
    }
    public void LoadPrevLevel()
    {
        StartCoroutine(LoadPrev(SceneManager.GetActiveScene().buildIndex - 1 ));
    }

    IEnumerator LoadPrev(int levelIndex)
    {
        transition.SetTrigger("Start"); 

        yield return new WaitForSeconds(transitionTime); 

        SceneManager.LoadScene(levelIndex); 
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadMenu(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadMenu(int levelIndex)
    {
        transition.SetTrigger("Start"); 

        yield return new WaitForSeconds(transitionTime); 

        SceneManager.LoadScene(levelIndex); 
    }
}
