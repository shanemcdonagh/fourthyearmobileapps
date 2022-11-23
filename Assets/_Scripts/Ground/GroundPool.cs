using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPool : MonoBehaviour
{
    public static GroundPool groundPoolSingleton;
    public List<GameObject> pooledItems;
    public GameObject itemToPool;
    public int amountToPool;

    void Awake()
    {
        // Create a singleton from this current class
        groundPoolSingleton = this;
    }

    void Start() 
    {
        pooledItems = new List<GameObject>();
        GameObject temp;

        for(int i=0; i < amountToPool; i++)
        {
            temp = Instantiate(itemToPool);
            temp.SetActive(false);
            pooledItems.Add(temp);  
        }
    }

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
