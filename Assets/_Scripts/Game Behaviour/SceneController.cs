using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class: Allows for transition between the scenes within the menu
public class SceneController : MonoBehaviour
{
    
    void Start()
    {
        // Ensures time returns to default when SceneController is instantiated (on menu load)
        Time.timeScale = 1f;
    }

    // Method: Can be called from any scene if applicable (Used by inspector on button click)
    public void BeginGame()
    {
        // Start the game
        SceneManager.LoadSceneAsync(1);
    }

    
    // Method: Can be called from any scene if applicable (Used by inspector on button click)
    public void BeginCoOp()
    {
        // Start the co-op mode
        SceneManager.LoadSceneAsync(2);
    }
}
