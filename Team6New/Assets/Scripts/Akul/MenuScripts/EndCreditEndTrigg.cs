using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditEndTrigg : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    


}

    





