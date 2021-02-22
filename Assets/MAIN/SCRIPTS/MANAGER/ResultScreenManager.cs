using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreenManager : MonoBehaviour
{

    // Start reveal of the screen


    // resutl calculations + animations

    // Next item tracker

    // best tracker

    // reveal animations

    public void GoToMainMenu()
    {
        // button Return to main menu
        SceneController.sceneController.LoadGame();
    }

    public void GoToShop()
    {
        // buttton Go to Shop
        SceneController.sceneController.LoadShop();
    }

    public void GoToContinue()
    {
        // button continue playing
        SceneController.sceneController.LoadGame();
    }
}
