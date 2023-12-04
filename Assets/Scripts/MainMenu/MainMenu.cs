using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class MainMenu : MonoBehaviour
{
    public float delayInSeconds = 1f;

    public void PlayGame()
    {
        
        StartCoroutine(DelayedLoadScene());
    }

    IEnumerator DelayedLoadScene()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayInSeconds);

        // Load the next scene based on the current build index + 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    public void QuitGame()
    {
        Application.Quit(); 
    }

}
