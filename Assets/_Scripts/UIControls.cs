using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControls : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;

    // Variables
    private float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        SingletonSetup();
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

    public void OnPlayerDeath()
    {

    }
}
