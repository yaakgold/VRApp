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
    public GameObject finalBox;
    public GameObject player;

    public void PlayGame()
    {
        //switch to game scene
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        //activate credits panel if not enabled
            //if enabled, activate main menu
        if(creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        //deactivate main menu if enabled
            //if not enabled, activate main menu
        else if(mainMenuPanel.activeInHierarchy)
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
