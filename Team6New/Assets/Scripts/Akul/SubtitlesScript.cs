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
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Suck ya nan";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "and do it again after";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
