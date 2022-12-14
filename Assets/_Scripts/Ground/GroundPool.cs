using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Allows to pool ground objects instead of creating new gameObjects constantly
public class GroundPool : MonoBehaviour
{
    public static GroundPool groundPoolSingleton;
    public List<GameObject> pooledItems;
    public GameObject itemToPool;
    public int amountToPool;

    // Called before Start method
    void Awake()
    {
        // Create a singleton from this current class
        groundPoolSingleton = this;
    }

    void Start() 
    {
        pooledItems = new List<GameObject>();
        GameObject temp;

        // Instantiate the amount of items specified and add them to the pool
        for(int i=0; i < amountToPool; i++)
        {
            temp = Instantiate(itemToPool);
            temp.SetActive(false);
            pooledItems.Add(temp);  
        }
    }

    // Method: Retrieve an item from the pool if it isn't currently active
    public GameObject GetGroundObject()
    {
        for(int i=0; i < amountToPool; i++)
        {
            if(!pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }
        return null;
    }
}
