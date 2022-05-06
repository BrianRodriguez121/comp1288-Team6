using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPad : MonoBehaviour
{
    public GameObject player;//object to move whe it touches the game object this is attached too
    public Transform spawnPoint;//where it will move(all other scrits work the same movement is not stopped
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            player = col.transform.gameObject;
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("player teleported");
        }
    }
}


