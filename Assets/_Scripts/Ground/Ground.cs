using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    // Instance variable - To use methods within GroundSpawner
    GroundSpawner gs;
    public List<GameObject> obstacles;
    public List<GameObject> powers;
    public int[] powerRarity;
    private bool firstPlatform;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve game object containing GroundSpawner script
        gs = GameObject.FindObjectOfType<GroundSpawner>();

        for(int i = 0; i < 15; i++)
        {
            SpawnPowers();
        }
        
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

        // Prevent stacking objects
        if(other.gameObject.tag == "Player")
        {
            // Spawn a new ground area for the player to traverse on
            gs.spawnTile();

            // Invoke method which deactivates gameobject after 3 seconds
            Invoke("SetToFalse",3.0f);
        }
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

        // Select the first obstacle in the array initially
        GameObject obstacle = obstacles[0];

        // Attempt at spawning obstacles based on the current level
        // do
        // {
        //     obstacle = obstacles[Random.Range(0,3)];
        // } while(obstacle.GetComponent<Obstacle>().ObstacleLevel > GameObject.FindObjectOfType<GameBehaviour>().GetLevel());

        // Firstly chooses a random obstacle and then continues to do so until it picks a random obstacle that can be spawned at the current level
        // do
        // {
            // Select a random obstacle
            int obstacleNumber = Random.Range(0,5);
            obstacle = obstacles[obstacleNumber];
            //Debug.Log("Current Level: " + GameObject.FindObjectOfType<GameBehaviour>().GetLevel());

        // } while(obstacle.GetComponent<Obstacle>().ObstacleLevel > 2);


        if(obstacle.name.Contains("Long Stone Wall"))
        {
            // Spawn obstacle in the middle of the ground
            randomSpawnPoint = 3;
        }

        Transform spawn = transform.GetChild(randomSpawnPoint).transform;

        // Instantiate the obstacle at the random spawn point and make it a parent of ground tile
        // This is important as it will destroy the obstacles as the ground gets destroyed
        Instantiate(obstacle, new Vector3(spawn.position.x,obstacle.transform.position.y,spawn.position.z), obstacle.transform.rotation, transform);

    }

    private void SpawnPowers()
    {

        // Find a way to decrease odds of heart and increase odds of cheese

        // First, check if the player still is alive (has health remaining)
        if(PlayerBehaviour.isPlayerDead)
        {
            // If the player is dead, exit the method
            return;
        }

        // Shuffle the list of obstacles to use
        Utils.Shuffle(powers);

        // Select a random point to spawn the obstacle
        int randomSpawnPoint = Random.Range(2,5);

        Transform spawn = transform.GetChild(randomSpawnPoint).transform;

        // Select a random power from the list
        int powerNumber = Random.Range(0,5);
        GameObject power = powers[powerNumber];

       // while(Random.Range(0,100) <= powerRarity[powerNumber])

        // Vector3 spawn = new Vector3(spawn.position.x,power.transform.position.y,spawn.position.z);

        // Instantiate the power at the random spawn point and make it a parent of ground tile
        // This is important as it will destroy and powers left over if the player doesn't pick them up
        // int rarity = Random.Range(0,100);
        // Debug.Log("Rarity: " + rarity + "Item Rarity: " + powerRarity[powerNumber]);

        Instantiate(power, new Vector3(spawn.position.x,power.transform.position.y,spawn.position.z), power.transform.rotation, transform);
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
