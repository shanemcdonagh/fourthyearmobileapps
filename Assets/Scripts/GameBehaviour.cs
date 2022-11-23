using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private float highScore;

    [SerializeField] private int currLevel;

    // Used to determine a myriad of factors - Player speed, obstacle spawns etc. (important to be viewable in these classes)
    //public static int GetLevel{get{return currLevel;}}
    public int GetLevel() { return currLevel; }

    // Important for player speed
    public float Highscore { get {return highScore;} }

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial values necessary
        highScore = 0;
        currLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Will be used to update the UI
    }

    // Invoked when the player collects the cheese power-up
    public void updateHighScore(float value)
    {   
        highScore += value;
        Debug.Log("Highscore: " + highScore);

        // Check if the player has a high enough score to reach the next level
        checkScore();
    }

    // Method: Check to see if the current high score qualifies the player to move to the next level
    private void checkScore()
    {
        // If: The current score is greater than or equal to 200 and less than 500..
        if(highScore >= 200 && highScore < 500)
        {
            // Change to level 2
            currLevel = 2;
        }
        else if(highScore >= 500)
        {
            // Change to level 3
            currLevel = 3;
        }
    }
}
