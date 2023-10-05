using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //  Loads the next scene when the player presses the play button in the main menu.
    }

    public void QuitGame()
    {
        Application.Quit();
        //  Quits the game when the player presses the quit button in the main menu.
    }
}
