using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void BeginGame()
    {
        // Start the game
        SceneManager.LoadSceneAsync(1);
    }

    public void BeginCoOp()
    {

    }
}
