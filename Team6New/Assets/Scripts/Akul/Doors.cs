using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //Door will only accept the "key" accociated with it . if correct key is in inventory door asses is destroyed /opened
    public string doorColour;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (doorColour == "NoteOne" && GlobalData.NoteOne)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (doorColour == "NoteTwo" && GlobalData.NoteTwoKey)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (doorColour == "NoteThree" && GlobalData.NoteThree)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (doorColour == "NoteFour" && GlobalData.NoteFour)
                Destroy(gameObject);
        }
    }

}