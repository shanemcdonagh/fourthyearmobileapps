using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Method: Used for in game menu and for game over control
public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    private bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        // If: The user pressed the Escape key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // If: The game is already paused..
            if(gamePaused)
            {
                // Resume the game
                resume();
            }
            else
            {
                // Pause the game
                pause();
            }
        } 
    }

    // Method: De-activates pause menu and restore normal game time
    private void resume()
    {
        // Set menu to false and restore time
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    // Method: Opens the Pause Menu and stops game time
    private void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    // Method: When quit menu is pressed, this method is invoked (also used by game over menu)
    public void LoadMenu()
    {
        Time.timeScale = 1f;

        // Reload the menu scene
        SceneManager.LoadSceneAsync(0);
    }

    // Method: Used for resuming with a button click 
    public void ResumeGame()
    {
        // Invoke private method to resume the game
        resume();
    }

    // Method: When restart menu is pressed, this method is invoked (also used by game over menu)
    public void RestartGame()
    {
        Time.timeScale = 1f;

        // Reload the game scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
