using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject floorTile;
    private Vector3 nextGroundItem;

    public void spawnTile()
    {
        GameObject currentFloor = Instantiate(floorTile, nextGroundItem, Quaternion.identity);
        nextGroundItem = currentFloor.transform.GetChild(1).transform.position;
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
