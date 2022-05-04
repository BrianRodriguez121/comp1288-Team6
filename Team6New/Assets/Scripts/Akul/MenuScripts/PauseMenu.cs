using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;

    public GameObject pausMenuUI;



    public FPSController fpsController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }
    }


    public void Resume()
    {
        pausMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpsController.lookSpeed = 2;
    }


    public void Pause()
    {
        pausMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpsController.lookSpeed = 0;
    }


    public void Restart()
    {
        SceneManager.LoadScene("Lukas_Map_AI");
        
    }

    public void Objectives()
    {


    }




}
