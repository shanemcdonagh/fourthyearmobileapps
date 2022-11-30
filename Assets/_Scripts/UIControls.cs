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



    // Variables
    private float score = 0;

    //public int timer;
    //public TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
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
            score = GameObject.FindObjectOfType<GameBehaviour>().Highscore;
            scoreText.text = score.ToString();
        }
    }

    // Reference: https://youtu.be/ulxXGht5D2U
    IEnumerator startCountdown()
    {
        Time.timeScale = 0f;

        while(timer > 0)
        {
            
            // Update the timer text
            timerText.text = timer.ToString();

            // Wait a second
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("bruh");

            // Decrease the time
            timer--;
        }

        // Toggle the text off 
        timerText.gameObject.SetActive(false);
        Time.timeScale = 1f;

        // Wait a second
       // yield return new WaitForSeconds(1f);

        
    }
}
