using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    //This script should be put on the canvas.
    
    public static bool gameIsPaused = false;

    //This is the pause menu overlay and it will be set to inactive at first.
    public GameObject pauseMenuUI;

    public GameObject player;
    
    void Update()
    {
        //Escape key to exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                //This function is below this
                Resume();
            }
            else
            {
                //Ditto (not the pokemon)
                Pause();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gameIsPaused)
            {
                LoadMenu();
            }

            else
            {
                Debug.Log("Dont go to menu");
            }
        }
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //The timescale function being set to 0 will essentially freeze the game
        Time.timeScale = 0f;
        gameIsPaused = true;
        //Disable player and thus the player script
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }


    public void LoadMenu()
    {
        //Want to make sure the game doesnt stay frozen when going to the menu
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");
        Application.Quit();
    }
}
