using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour
{

    //Classic Global data code will need to read and look at what it can do and make adjustments



    // varables.
    public Vector3 lastCheckPoint;
    public Transform startPos;
    public GameObject player;

    //Keys colours for door/key varables
    static public bool Coin = false;
    static public bool Coin1 = false;
    static public bool Coin2 = false;
    static public bool Coin3 = false;


    //parts that apply to UI
    static public bool paused = false;
    static public bool gameOver = false;
    public GameObject endGame;

    
    public GameObject pauseMenu;
    

    //starts before first playthrough
    void Start()
    {
        Time.timeScale = 1f;
        //sends player to start point
        lastCheckPoint = startPos.position;
        player.transform.position = lastCheckPoint;
                
        pauseMenu.SetActive(false);
        player.SetActive(true);
        
        gameOver = false;
    }



    //When "esc" key pressed UI menu opens
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseMenu();
            }
            else
            {
                Unpause();
            }
        }
    }

    //Pause game when Menue open Code
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Debug.Log("resume button pressed");
    }

    

    //UI Quit to menu button
    public void QuitToMenu() //will change the game to the quit to menu is clicked.
    {
        SceneManager.LoadScene("MainMenu");
    }

    //UI quite game button
    public void QuitGame()
    {
        Application.Quit();
    }

    //UI Start Main Game
    public void StartGame()
    {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Debug.Log("gameloaded");
    }

    public void GameOver() //will change the game to the quit to menu is clicked.
    {
        endGame.SetActive(true);
        player.SetActive(false);
        gameOver = true;
    }
}
