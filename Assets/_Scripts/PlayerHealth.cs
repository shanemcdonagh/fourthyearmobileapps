using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    //public float GetCurrentHealth(){return currentHealth};


    // Start is called before the first frame update
    void Start()
    {
        // Set the current health to max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method: Called when the obstacle comes into contact with the player
    public void TakePlayerDamage(int damage)
    {
        currentHealth -= damage;
        GameObject.FindObjectOfType<HealthUI>().UpdateHealthBar(currentHealth);
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            PlayerBehaviour.isPlayerDead = true;
        }
    }

    // Method: Called when a heart comes into contact with the player (Heart.cs)
    public void IncreasePlayerHealth(int health)
    {
        if(currentHealth <=100 && currentHealth > 0)
        {
            currentHealth+=health;
            GameObject.FindObjectOfType<HealthUI>().UpdateHealthBar(currentHealth);
        }
    }
}
