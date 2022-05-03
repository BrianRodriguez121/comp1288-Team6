using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //Door will only accept the "key" accociated with it . if correct key is in inventory door assets is destroyed /opened
    public string Stage;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Stage == "Stage1Key" && GlobalData.Stage1Key)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (Stage == "Stage2" && GlobalData.Stage2)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (Stage == "Stage3" && GlobalData.Stage3)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (Stage == "Stage 4" && GlobalData.Stage4)
                Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Player")
        {
            if (Stage == "Stage 5" && GlobalData.Stage5)
                Destroy(gameObject);
        }
    }

}