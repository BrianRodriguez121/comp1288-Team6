using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{

    public AudioClip ClipToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Vocals.instance.Say(ClipToPlay);
    }


}
