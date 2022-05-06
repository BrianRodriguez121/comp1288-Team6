using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject Panel;

    public GameObject OptionsPanel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }



    public void OpenOptionsPanel()
    {
        if (OptionsPanel != null)
        {
            OptionsPanel.SetActive(true);
        }
    }

    public void CloseOptionsPanel()
    {
        if (OptionsPanel != null)
        {
            OptionsPanel.SetActive(false);
        }
    }
}
