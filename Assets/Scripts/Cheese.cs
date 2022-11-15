using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    // Activates when the something collides with the cheese
    private void OnTriggerEnter(Collider other) 
    {
        // Check if the gameobject in question is the player
        if(other.gameObject.tag == "Player")
        {
            // Update the player score
            
        }
    }
}
