using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Used to increase the players high score
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
            
            // Play sound clip and destroy object
            SoundManager.SoundManagerInstance.PlayClip("Power Up");
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Power" || other.gameObject.tag == "Heart")
        {
            // If it isn't the player, destroy the object
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        // Rotate the gameObject
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
