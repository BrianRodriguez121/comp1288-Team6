using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    /*public AudioSource Veiler_spookygong;*/

    public string keyColour;
    // Start is called before the first frame update
    //When player tag collides with "key" player picks up item. Each key is unique
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Coin")
            {
                GlobalData.Coin = true;
                print("Coin picked up");
                /*Veiler_spookygong.Play();*/
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Coin1")
            {
                GlobalData.Coin1 = true;
                print("Coin1 Key picked up");
                /*Veiler_spookygong.Play();*/
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Coin2")
            {
                GlobalData.Coin2 = true;
                print("Coin2 picked up");
                /*Veiler_spookygong.Play();*/
            }

            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Coin3")
            {
                GlobalData.Coin3 = true;
                print("Coin4 picked up");
               /* Veiler_spookygong.Play();*/
            }

            Destroy(gameObject);

        }

    }
}