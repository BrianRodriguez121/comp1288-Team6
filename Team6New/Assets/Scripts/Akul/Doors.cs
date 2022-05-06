using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //Door will only accept the "key" accociated with it . if correct key is in inventory door asses is destroyed /opened
    public string doorKey;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("coll with door");
            if (doorKey == "Coin" && GlobalData.Coin)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (doorKey == "Coin1" && GlobalData.Coin1)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (doorKey == "Coin2" && GlobalData.Coin2)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (doorKey == "Coin3" && GlobalData.Coin3)
                Destroy(gameObject);
        }
    }

}
