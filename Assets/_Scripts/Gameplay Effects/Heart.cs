using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Used to heal the players health
public class Heart : MonoBehaviour
{
    [SerializeField] private int health = 30;
    [SerializeField] private float turnSpeed = 90f;

    // Activates when something collides with the gameObject
    private void OnTriggerEnter(Collider other) 
    {
        // If: The powerup is spawned on an obstacle or another power
        if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Power")
        {
            // Destroy the gameObject
            Destroy(gameObject);
        }

        // Check if the gameobject in question is the player and they need health...
        if(other.gameObject.name.Contains("Player") && GameObject.FindObjectOfType<PlayerHealth>().GetCurrentHealth() < 100)
        {
            // Update the players health and play a sound
            SoundManager.SoundManagerInstance.PlayClip("Health");
            GameObject.FindObjectOfType<PlayerHealth>().IncreasePlayerHealth(health);
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        // Rotate the gameObject based on set turnSpeed
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
