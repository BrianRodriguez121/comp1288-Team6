using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigg : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            SceneManager.LoadScene("EndCredits");
            Debug.Log("End Creddit Trigger");
        }
    }
}
