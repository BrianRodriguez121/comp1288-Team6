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
        textBox.GetComponent<Text>().text = "Emergency protocol activated.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "*DANGER*";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "INHABITED SPECIES ARE A THREAT, LEAVE IMMEDIATELY.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "*DANGER*";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "*Shipwreck protocol initiated*";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Ship no longer viable. You must leave this area as soon as possible.";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<Text>().text = "Do not trust indiginus species. Keep moving.";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Weapons system active. Hold Tab to Select. F & C to control Spectrum";
        yield return new WaitForSeconds(3);
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
