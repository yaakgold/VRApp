using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    //TODO
    //have the scene switch to the main menu scene

    public void PlayGame()
    {
        //switch to game scene
    }

    public void Credits()
    {
        //activate credits panel if not enabled
            //if enabled, activate main menu
        //deactivate main menu if enabled
            //if not enabled, activate main menu
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
