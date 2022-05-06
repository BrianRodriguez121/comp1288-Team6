using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EngGameColTrigger : MonoBehaviour
{

    //To be putt onto the object droppped by main boss or code merged with

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
