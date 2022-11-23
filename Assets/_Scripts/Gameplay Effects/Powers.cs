using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{

    [SerializeField] private float points = 10;
    [SerializeField] private float turnSpeed = 90f;

    // Activates when the something collides with the cheese
    private void OnTriggerEnter(Collider other) 
    {
        // If the powerup is spawned on an obstacle
        if (other.gameObject.GetComponent<Obstacle>() != null) 
        {
            Destroy(gameObject);
            return;
        }
        
        // Check if the gameobject in question is the player
        if(other.gameObject.tag == "Player")
        {
            // Update the player score
            GameObject.FindObjectOfType<GameBehaviour>().updateHighScore(points);
            
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        // Rotate the gameObject
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
