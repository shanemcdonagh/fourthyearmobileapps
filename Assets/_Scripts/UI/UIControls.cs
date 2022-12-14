using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Method: Used to update the UI elements in-game
public class UIControls : MonoBehaviour
{

    // UI attributes that need to be updated
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private int timer;
    [SerializeField] private TextMeshProUGUI timerText;
    
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI levelText;

    // Variables
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set level text and game over menu false
        levelText.gameObject.SetActive(false);
        gameOverMenu.SetActive(false);

        // Begin coroutines (start the countdown of the game and display current level)
        StartCoroutine(startCountdown());
        StartCoroutine(NewLevelText("Level 1"));
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI elements
        uiUpdate();
    }

    // Method: Ennsures this current gameObject is exclusive (exists once)
    private void SingletonSetup()
    {
        // If: More than one GameObject contains this script...
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // Destroy current gameObject
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Can be called when players health or score is affected
    public void uiUpdate()
    {
        if(gameObject != null)
        {
            // If the player is still alive...
            if(!PlayerBehaviour.isPlayerDead)
            {
                // Update the current highscore
                score = GameObject.FindObjectOfType<GameBehaviour>().Highscore;
                scoreText.text = score.ToString();
                gameOverScoreText.text = score.ToString();
            }
            else
            {
                //SoundManager.SoundManagerInstance.PlayClip("GO");
                Time.timeScale = 0;

                // Stop game music, and activate game over menu
                SoundManager.SoundManagerInstance.StopClip("Menu Music");
                gameOverMenu.SetActive(true);
            }  
        }
    }

    // Reference: https://youtu.be/ulxXGht5D2U
    // Coroutine: Begins the game countdown
    private IEnumerator startCountdown()
    {
        GameObject player1 = GameObject.FindObjectOfType<PlayerBehaviour>().gameObject;
        GameObject player2 = GameObject.FindObjectOfType<PlayerBehaviour1>().gameObject;

        // Lets other gameObjects scripts work first before stopping time (allows game over menu to be set back to false)
        yield return new WaitForSecondsRealtime(0.01f);

        // Pause time and prevent the pause menu to be used or the players to be moved
        Time.timeScale = 0f;
        player1.GetComponent<PlayerBehaviour>().enabled = false;
        player2.GetComponent<PlayerBehaviour1>().enabled = false;
        GameObject.FindObjectOfType<PauseMenu>().enabled = false;
        
        while(timer > 0)
        {
            // Update the timer text
            timerText.text = timer.ToString();

            // Wait a second
            yield return new WaitForSecondsRealtime(1f);

            // Decrease the time
            timer--;
        }

        // Toggle the timer text off and resume time
        timerText.gameObject.SetActive(false);
        Time.timeScale = 1f;

        // Enable scripts 
        player1.GetComponent<PlayerBehaviour>().enabled = true;
        player2.GetComponent<PlayerBehaviour1>().enabled = true;
        GameObject.FindObjectOfType<PauseMenu>().enabled = true;
    }

    // Coroutine: Display current level on every level change
    public IEnumerator NewLevelText(string level)
    {
        levelText.text = level;
        levelText.gameObject.SetActive(true);

        // Wait a second
        yield return new WaitForSeconds(2f);
        levelText.gameObject.SetActive(false);
    }
}
