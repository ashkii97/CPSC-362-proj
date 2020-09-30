using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
        /*
         * This script runs when the PLAY button is activated.  The Scene manager gets the current index of the active scene and loads the next scene in the sequence.
         * Current scene build order:
         * Scene            Index
         * ______________________
         * Menu             0
         * TowerPlace..     1
         * 
         * The order may be edited in File -> Build Settings
         * Drag the desired scene into the box to give it an index
         */
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    /*
    * This script runs when the QUIT button is activated.  A "PLAYER QUIT" message will be output to the console for testing purposes, then the application will be terminated.
    */
    {
        UnityEngine.Debug.Log("PLAYER QUIT");
        Application.Quit();
    }
}
