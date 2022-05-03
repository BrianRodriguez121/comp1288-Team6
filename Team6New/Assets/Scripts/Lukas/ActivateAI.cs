using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateAI : MonoBehaviour
{
    public GameObject[] AIAreasActive;
    public GameObject[] AIAreasDeactive;

    public GameObject colliderActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            for(int i = 0; i < AIAreasActive.Length; ++i)
            {
                AIAreasActive[i].SetActive(true);
            }
            for (int i = 0; i < AIAreasDeactive.Length; ++i)
            {
                AIAreasDeactive[i].SetActive(false);
            }
            colliderActivate.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
