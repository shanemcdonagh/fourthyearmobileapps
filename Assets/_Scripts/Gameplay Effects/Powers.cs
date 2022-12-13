using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{

    [SerializeField] private int points = 10;
    [SerializeField] private float turnSpeed = 90f;

    // Activates when the something collides with the cheese
    private void OnTriggerEnter(Collider other) 
    {
        // Prevent stacking objects
        if(other.gameObject.tag.Contains("Player"))
        {
            // Update the player score
            GameObject.FindObjectOfType<GameBehaviour>().updateHighScore(points);
            
            SoundManager.SoundManagerInstance.PlayClip("Power Up");
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Power" || other.gameObject.tag == "Heart")
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        // Rotate the gameObject
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
