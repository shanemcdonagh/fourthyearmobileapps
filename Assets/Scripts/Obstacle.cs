using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private float damage = 10;


    // Method: Called when another collider comes into contact with the current gameObject
    private void OnTriggerEnter(Collider other) 
    {
        // Check if the gameobject in question is the player
        if(other.gameObject.tag == "Player")
        {
            // Cause damage to the player based on damage set
            GameObject.FindObjectOfType<PlayerHealth>().TakePlayerDamage(damage);
            //PlayerHealth.TakePlayerDamage(damage);
        }
    }
}
