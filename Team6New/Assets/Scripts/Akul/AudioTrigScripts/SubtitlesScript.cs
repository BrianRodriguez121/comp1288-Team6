using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitlesScript : MonoBehaviour
{

    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }


    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);//time the text one sceneen is showed before changing
        textBox.GetComponent<Text>().text = "SUBTITLES ON";
        yield return new WaitForSeconds(3);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
