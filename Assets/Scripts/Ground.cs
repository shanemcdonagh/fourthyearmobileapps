using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    // Instance variable - To use methods within GroundSpawner
    GroundSpawner gs;


    // Start is called before the first frame update
    void Start()
    {
        // Retrieve game object containing GroundSpawner script
        gs = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Method: Triggered when an object or collider exits the collider on the current game object
    private void OnTriggerExit(Collider other) 
    {
        // Spawn a new ground area for the player to traverse on
        gs.spawnTile();

        // Destroy this current gameobject after 3 seconds (after player precedes past it)
        Destroy(this.gameObject,3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
