using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int health = 30;
    [SerializeField] private float turnSpeed = 90f;

    // Activates when the something collides with the cheese
    private void OnTriggerEnter(Collider other) 
    {
        // If the powerup is spawned on an obstacle
        if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Power")
        {
           // Debug.Log("Destroyed " + gameObject.name);
            Destroy(gameObject);
        }

        if(gameObject.name.Contains("Heart"))
        {
            
        }
        
        // Check if the gameobject in question is the player
        if(other.gameObject.tag == "Player" && GameObject.FindObjectOfType<PlayerHealth>().GetCurrentHealth() < 100)
        {
            // Update the player score
            SoundManager.SoundManagerInstance.PlayClip("Health");
            GameObject.FindObjectOfType<PlayerHealth>().IncreasePlayerHealth(health);
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        // Rotate the gameObject
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
