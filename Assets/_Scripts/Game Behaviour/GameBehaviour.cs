using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Controls the basic game behaviour (high score, current level etc.)
public class GameBehaviour : MonoBehaviour
{
    private int highScore;

    [SerializeField] private int currLevel;
    private GameObject parentCanvas;
    private GameObject childCanvas;

    // Used to determine a myriad of factors - Player speed, obstacle spawns etc. (important to be viewable in these classes)
    public int GetLevel() { return currLevel; }

    // Important for player speed and the UI
    public float Highscore { get {return highScore;} }

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial values necessary
        highScore = 0;
        currLevel = 1; 
    }

    // Method: Invoked when the player collects the cheese power-up or collects a power-down
    public void updateHighScore(int value)
    {   
        // Add to the high-score
        highScore += value;

        // Check if the player has a high enough score to reach the next level
        checkScore();
    }

    // Method: Check to see if the current high score qualifies the player to move to the next level
    private void checkScore()
    {
        // If: The current score is greater than or equal to 200 and less than 300..
        if(highScore >= 200 && highScore < 300)
        {
            // Change to level 2
            currLevel = 2;
        }
        if(highScore >= 300)
        {
            // Change to level 3
            currLevel = 3;
        }
    }
}
