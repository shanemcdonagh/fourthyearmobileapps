using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    // Instance variable - To use methods within GroundSpawner
    GroundSpawner gs;
    public List<GameObject> obstacles;


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

        // Invoke method which deactivates gameobject after 3 seconds
        Invoke("SetToFalse",3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetToFalse()
    {
        // Deactivate object so it returns to pool
        gameObject.SetActive(false);
    }

    private void SpawnEnemyObstacle()
    {
        // Select a random point to spawn the obstacle
        int randomSpawnPoint = Random.Range(2,5);

        // Select a random obstacle to spawn
        int randomObstacle = Random.Range(0,2);
    }
}
