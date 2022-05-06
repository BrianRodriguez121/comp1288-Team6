using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    //Press K to pause the game dueing presentation
    public static bool GameIsPaused = true;

    public GameObject pausMenuUI;

    public FPSController fpsController;
    public WeaponSystem weaponsystem;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();
                Weapon weapon = weaponsystem.GetWeaponCompenet(weaponsystem.weaponIndex);
                weapon.canShoot = true;
            }
            else
            {
                Pause();
                Weapon weapon = weaponsystem.GetWeaponCompenet(weaponsystem.weaponIndex);
                weapon.canShoot = false;

            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

            if (GameIsPaused)
            {
                PresentationResume();
            }
            else
            {
                PresentationPause();

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


    //Pause Button For Presentation use
    public void PresentationResume()
    {
        
        Time.timeScale = 1f;
        GameIsPaused = false;
              
       
        fpsController.lookSpeed = 2;
    }


    public void PresentationPause()
    {
       
        Time.timeScale = 0f;
        GameIsPaused = true;
               
        
        fpsController.lookSpeed = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Lukas_Map_AI");
        
    }

    public void Objectives()
    {


    }




    public void QuitToMenu() //will change the game to the quit to menu is clicked.
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void QuitGame()
    {
        Application.Quit();
    }



}
