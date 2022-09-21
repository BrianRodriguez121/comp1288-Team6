using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnColBackToMenu : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MainCamera")
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("End Creddit Trigger");
        }
    }

}
