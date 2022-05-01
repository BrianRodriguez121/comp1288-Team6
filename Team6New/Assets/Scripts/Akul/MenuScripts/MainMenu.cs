using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
        SceneManager.LoadScene("Lukas");


    }


    public void Controls()
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game pressed");
    }


    public void MMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("quit game pressed");
    }


    public void SetVolume(float volume)
    {
        Debug.Log(volume); 
    }
}

