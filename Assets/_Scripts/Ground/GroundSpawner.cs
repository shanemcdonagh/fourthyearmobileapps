using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Used to spawn the ground object
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject floorTile;
    private Vector3 nextGroundItem; // Used to specify wherethe next item will spawn

    // Method: Used to spawn a given ground tile
    public void spawnTile()
    {
        // Select an object from the pool that isn't active
        GameObject floor = GroundPool.groundPoolSingleton.GetGroundObject();

        if(floor != null)
        {
            // Set its position based on where the inital position of the phantom is
            floor.transform.position = nextGroundItem;
            floor.transform.rotation = Quaternion.identity;

            // Update phantom and activate ground object
            nextGroundItem = floor.transform.GetChild(1).transform.position;
            floor.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initially spawn 10 tiles in front of the player
        for(int i=0; i < 10; i++)
        {
            // Spawn a tile
            spawnTile();
        } 
    }
}
