using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Used to cause health damage to the player
public class Obstacle : MonoBehaviour
{

    [SerializeField] private int damage = 10;

    // Method: Called when another collider comes into contact with the current gameObject
    private void OnTriggerEnter(Collider collider) 
    {
        // Check if the gameobject in question is the player
        if(collider.gameObject.name.Contains("Player"))
        {
            // Cause damage to the player based on damage set
            GameObject.FindObjectOfType<PlayerHealth>().TakePlayerDamage(damage);
        }
        else if(collider.gameObject.tag == "Obstacle" || collider.gameObject.tag == "Power")
        {
            // Otherwise, if it's another obstacle or power, destroy the other gameobject
            Destroy(collider.gameObject);
        }
    }
}
