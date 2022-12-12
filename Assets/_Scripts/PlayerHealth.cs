using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Material material;
    private int currentHealth;
    private Color originalColor;
    private float damageTime = 0.15f;

    // Prevents hearts from being consumed if player is full
    public float GetCurrentHealth(){return currentHealth;}


    // Start is called before the first frame update
    void Start()
    {
        // Set the current health to max health
        currentHealth = maxHealth;
        originalColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method: Called when the obstacle comes into contact with the player
    public void TakePlayerDamage(int damage)
    {
        if(!Star.isInvincible)
        {
            currentHealth -= damage;
            GameObject.FindObjectOfType<HealthUI>().UpdateHealthBar(currentHealth);
            SoundManager.SoundManagerInstance.PlayClip("Damage");
            StartCoroutine(damageFlash());
            Debug.Log(currentHealth);
        }
       
        if(currentHealth <= 0)
        {
            PlayerBehaviour.isPlayerDead = true;
        }
    }

   private IEnumerator damageFlash()
   {
        material.color = Color.red;

        yield return new WaitForSeconds(1.0f);
        
        material.color = originalColor;
   }

    // Method: Called when a heart comes into contact with the player (Heart.cs)
    public void IncreasePlayerHealth(int health)
    {
        if(currentHealth < 100 && currentHealth > 0)
        {
            currentHealth+=health;
            GameObject.FindObjectOfType<HealthUI>().UpdateHealthBar(currentHealth);
            Debug.Log(currentHealth);
        }
    }
}
