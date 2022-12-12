using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    void Start()
    {
        // Delegate event, receives callbacks when new scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Ensures each scenes timescale gets reset
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;
    }
    
    
    public void BeginGame()
    {
        // Start the game
        SceneManager.LoadSceneAsync(1);
    }

    public void BeginCoOp()
    {
        // Start the co-op mode
        SceneManager.LoadSceneAsync(2);
    }
}
