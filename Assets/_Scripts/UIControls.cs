using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverMenu;

    // Variables
    private float score = 0;

    //public int timer;
    //public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        StartCoroutine(startCountdown());
    }

    // Update is called once per frame
    void Update()
    {
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
            

            if(!PlayerBehaviour.isPlayerDead)
            {
                score = GameObject.FindObjectOfType<GameBehaviour>().Highscore;
                scoreText.text = score.ToString();
            }
            else
            {
                Time.timeScale = 0;
                gameOverMenu.SetActive(true);
            }  
        }
    }

    // Reference: https://youtu.be/ulxXGht5D2U
    IEnumerator startCountdown()
    {
        GameObject player = GameObject.FindObjectOfType<PlayerBehaviour>().gameObject;

        // Lets other gameObjects scripts work first before stopping time (allows game over menu to be set back to false)
        yield return new WaitForSecondsRealtime(0.01f);

        Time.timeScale = 0f;
        player.GetComponent<PlayerBehaviour>().enabled = false;
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

        // Toggle the text off 
        timerText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerBehaviour>().enabled = true;
        GameObject.FindObjectOfType<PauseMenu>().enabled = true;


        // Wait a second
       // yield return new WaitForSeconds(1f);        
    }
}
