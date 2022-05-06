using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{

    private AudioSource source;

    public static Vocals instance;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(AudioClip clip)
    {
        if (source.isPlaying)
           source.Stop();

            source.PlayOneShot(clip);
        
        
    }
}
