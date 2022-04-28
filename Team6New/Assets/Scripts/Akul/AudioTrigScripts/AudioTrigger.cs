using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{


    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //is finding the audio attached to the game object this script is attached too.
    }

    void OnTriggerEnter()//will trigger when any game Object passes though the objaect this is attached too.
    {
        Debug.Log("Audio redirecting audio");

        audioSource.Play();
    }



    // Update is called once per frame
    void Update()
    {

    }
}