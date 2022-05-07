using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject ObjectivesPanel;

    public GameObject OptionsPanel;

    public GameObject ControlsPanel;
    public GameObject MovementControlsPanel;
    public GameObject WeaponsControlsPanel;

    public void OpenPanel()
    {
        if (ObjectivesPanel != null)
        {
            ObjectivesPanel.SetActive(true);
            /*FindObjectOfType<AudioManager>().Play(ButtonAudio);*/
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


    //
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

    //MovementControlsPanel
    public void OpenMovementControlsPanel()
    {
        if (MovementControlsPanel != null)
        {
            MovementControlsPanel.SetActive(true);
        }
    }

    public void CloseMovementControlsPanel()
    {
        if (MovementControlsPanel != null)
        {
            MovementControlsPanel.SetActive(false);
        }
    }

    //WeaponsControlsPanel
    public void OpenWeaponsControlsPanel()
    {
        if (WeaponsControlsPanel != null)
        {
            WeaponsControlsPanel.SetActive(true);
        }
    }

    public void CloseWeaponsControlsPanel()
    {
        if (WeaponsControlsPanel != null)
        {
            WeaponsControlsPanel.SetActive(false);
        }
    }

    //Close all controller panels
    public void CloseAllControlsPanel()
    {
        if (WeaponsControlsPanel != null)
        {
            WeaponsControlsPanel.SetActive(false);
        }

        if (MovementControlsPanel != null)
        {
            MovementControlsPanel.SetActive(false);
        }
    }
}
