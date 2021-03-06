using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{

    //Smooth scene tranisiton code
    public Animator transition;
    public float transitionTime = 1f;


    //Volume control
    public AudioMixer audioMixer;

    //Subtitles code
    public GameObject SubPanel;

    void start()
    {

        if (Input.GetMouseButtonDown(0))
        {

           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
        }
    }

    
       

    //Menu buttons

    public void PlayGame()
    {
        
        SceneManager.LoadScene("Lukas_Map_AI");
        

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
        Debug.Log("MMenu game pressed");
    }




    //options buttons

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume); 
    }



    public void SubToggle()
    {
        //Add code to toggle Subtitle text on canvas
        if (SubPanel != null)
        {
            bool isActive = SubPanel.activeSelf;
            SubPanel.SetActive(!isActive);
        }
    }


    //Grphics levels

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    //FULL SCREEN

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("fullscreen selected");
    }

}

