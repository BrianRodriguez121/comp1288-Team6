using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public string keyColour;
    // Start is called before the first frame update
    //When player tag collides with "key" player picks up item. Each key is unique
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "NoteOne")
            {
                GlobalData.NoteOne = true;
                print("NoteOne picked up");
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "NoteTwo")
            {
                GlobalData.NoteTwoKey = true;
                print("NoteTwo Key picked up");
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "NoteThree")
            {
                GlobalData.NoteThree = true;
                print("NoteThree picked up");
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "NoteFour")
            {
                GlobalData.NoteFour = true;
                print("NoteFour picked up");
            }

            Destroy(gameObject);
        }

    }
}
