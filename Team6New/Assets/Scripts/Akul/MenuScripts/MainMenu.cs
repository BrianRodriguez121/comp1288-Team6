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

    public void LoadNextLevel()
    {

        /*StartCoroutine( SceneManager.LoadScene("Lukas"));*/

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        SceneManager.LoadScene(levelIndex);



    }


    //Menu buttons

    public void PlayGame()
    {
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
        SceneManager.LoadScene("Lukas");
        LoadNextLevel();

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

}

