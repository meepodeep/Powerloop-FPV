using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public LevelLoader LevelLoader; 
  public Animator animator;
  public GameObject DroneOff;
  public GameObject DroneOn; 
  public bool OptionsDown; 

  public void PlayGame ()
  {
    FindObjectOfType<AudioManagerMenu>().Play("ButtonPress");
    DroneOn.SetActive(true); 
    DroneOff.SetActive(false); 
    FindObjectOfType<AudioManagerMenu>().Play("PropNoiseM");
    animator.SetBool("Fly", true);
    StartCoroutine(start()); 
  }
  public void Tutorial()
  {
    FindObjectOfType<AudioManagerMenu>().Play("ButtonPress");
    StartCoroutine(tutorialc());
  }
  public void Options()
  {
    OptionsDown = true; 
    FindObjectOfType<AudioManagerMenu>().Play("ButtonPress");
    OptionsDown = false; 
  }
  public void Back()
  {
    FindObjectOfType<AudioManagerMenu>().Play("ButtonPress");
  }
  public void QuitGame()
  {
    FindObjectOfType<AudioManagerMenu>().Play("ButtonPress");
    StartCoroutine(Quit()); 
  }
  private IEnumerator Quit()
  {
    yield return new WaitForSeconds(.2f); 
    Debug.Log("Shit");
    Application.Quit();
  }
  private IEnumerator start()
    {
      yield return new WaitForSeconds(.9f);
      LevelLoader.LoadNextLevel();
    }
     private IEnumerator tutorialc()
    {
      yield return new WaitForSeconds(.2f);
      LevelLoader.LoadNextLevel();
      SceneManager.LoadScene("tutorial");
    }
}

