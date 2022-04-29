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
        SceneManager.LoadScene("OptionsScene");
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game pressed");
    }


    

}

