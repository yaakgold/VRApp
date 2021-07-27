using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO
    //have the scene switch to the main menu scene
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;

    public void PlayGame()
    {
        //switch to game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        //activate credits panel if not enabled
            //if enabled, activate main menu
        if(creditsPanel == enabled)
        {
            creditsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        //deactivate main menu if enabled
            //if not enabled, activate main menu
        else if(mainMenuPanel == enabled)
        {
            creditsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
