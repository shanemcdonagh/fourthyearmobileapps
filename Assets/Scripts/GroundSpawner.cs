using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject floorTile;
    private Vector3 nextGroundItem;

    public void spawnTile()
    {
        GameObject floor = GroundPool.groundPoolSingleton.GetGroundObject();

        if(floor != null)
        {
            floor.transform.position = nextGroundItem;
            floor.transform.rotation = Quaternion.identity;
            nextGroundItem = floor.transform.GetChild(1).transform.position;
            floor.SetActive(true);
        }
       // GameObject currentFloor = Instantiate(floorTile, nextGroundItem, Quaternion.identity);      
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
