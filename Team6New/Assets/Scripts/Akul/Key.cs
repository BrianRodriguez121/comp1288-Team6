using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public string keyColour;
    // Start is called before the first frame update
    //When player tag collides with "key" player picks up item. Each key is unique
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("stage one key collide");
            if (keyColour == "Stage1Key")
            {
                GlobalData.Stage1Key = true;
                print("Stage1 picked up");
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Stage2Key")
            {
                GlobalData.Stage2 = true;
                print("Stage2 Key picked up");
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Stage3Key")
            {
                GlobalData.Stage3 = true;
                print("Stage3 picked up");
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Stage4Key")
            {
                GlobalData.Stage4 = true;
                print("Stage4 picked up");
            }

            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Player")
        {
            if (keyColour == "Stage5Key")
            {
                GlobalData.Stage5 = true;
                print("Stage5 picked up");
            }

            Destroy(gameObject);
        }

    }
}
