using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject ObjectivesPanel;

    public GameObject OptionsPanel;
    public GameObject ControlsPanel;


    public void OpenPanel()
    {
        if (ObjectivesPanel != null)
        {
            ObjectivesPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (ObjectivesPanel != null)
        {
            ObjectivesPanel.SetActive(false);
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



    public void OpenControlsPanel()
    {
        if (ControlsPanel != null)
        {
            ControlsPanel.SetActive(true);
        }
    }

    public void CloseControlsPanel()
    {
        if (ControlsPanel != null)
        {
            ControlsPanel.SetActive(false);
        }
    }
}
