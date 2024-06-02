using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuListeners : MonoBehaviour
{
    public GameObject settingsPanel;

    void Start()
    {
        // Hide the settings panel when the game starts
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Office");
    }

    public void SettingsButtonClicked()
    {
        // Toggle the settings panel visibility
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}
