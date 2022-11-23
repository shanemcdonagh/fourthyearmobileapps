using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    // Instance variable - To use methods within GroundSpawner
    GroundSpawner gs;
    public List<GameObject> obstacles;
    private bool firstPlatform;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve game object containing GroundSpawner script
        gs = GameObject.FindObjectOfType<GroundSpawner>();

        SpawnEnemyObstacle();
    }

    // Method: Triggered when an object or collider exits the collider on the current game object
    private void OnTriggerExit(Collider other) 
    {
        // First, check if the player still is alive (has health remaining)
        if(PlayerBehaviour.isPlayerDead)
        {
            // If the player is dead, exit the method
            return;
        }

        // Spawn a new ground area for the player to traverse on
        gs.spawnTile();

        // Invoke method which deactivates gameobject after 3 seconds
        Invoke("SetToFalse",3.0f);
    }

    private void SetToFalse()
    {
        // Deactivate object so it returns to pool
        gameObject.SetActive(false);
    }

    private void SpawnEnemyObstacle()
    {

        // First, check if the player still is alive (has health remaining)
        if(PlayerBehaviour.isPlayerDead)
        {
            // If the player is dead, exit the method
            return;
        }

        // Shuffle the list of obstacles to use
        Utils.Shuffle(obstacles);

        // Select a random point to spawn the obstacle
        int randomSpawnPoint = Random.Range(2,5);

        Transform spawn = transform.GetChild(randomSpawnPoint).transform;

        // Select a random obstacle
       // GameObject obstacle = obstacles[Random.Range(0,2)];

        // Select the first obstacle in the array initially
        GameObject obstacle = obstacles[0];

        // Firstly chooses a random obstacle and then continues to do so until it picks a random obstacle that can be spawned at the current level
        do
        {
            // Select a random obstacle
            obstacle = obstacles[Random.Range(0,2)];

        } while(obstacle.GetComponent<Obstacle>().ObstacleLevel > 2);

        // if(obstacle.tag == "Barrier")
        // {
        //     spawn.position = new Vector3(spawn.position.x, -0.26f, transform.position.z);
        // }

        // Instantiate the obstacle at the random spawn point and make it a parent of ground tile
        // This is important as it will destroy the obstacles as the ground gets destroyed
        Instantiate(obstacle, new Vector3(spawn.position.x,obstacle.transform.position.y,spawn.position.z), obstacle.transform.rotation, transform);

    }
}

public static class Utils
{
    // fisher yeats shuffle
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(this IList<T> theList)
    {
        int n = theList.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            T value = theList[k];
            theList[k] = theList[n];
            theList[n] = value;
        }
    }
}  
