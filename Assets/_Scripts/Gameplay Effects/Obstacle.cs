using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private int damage = 10;
    [SerializeField] public int levelToSpawn;

    // Specifies an obstacle level in which the object can spawn at
    public int ObstacleLevel { get {return levelToSpawn;} }

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
           // Debug.Log("Destroyed " + gameObject.name);
            Destroy(collider.gameObject);
        }
    }
}
