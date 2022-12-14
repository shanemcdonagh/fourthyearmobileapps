using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://answers.unity.com/questions/700255/powerup-script-to-make-player-invincible.html
// Class: Used to give the player invincibility based on a timer
public class Star : MonoBehaviour
{
    public static bool isInvincible = false;
    [SerializeField] private float invincibilityTimer = 3.0f;
    [SerializeField] private float turnSpeed = 90f;

    private void Update() 
    {
        // Rotate the gameObject
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }

    // Activates when the something collides with the cheese
    private void OnTriggerEnter(Collider other) 
    {
        // Prevent stacking objects
        if(other.gameObject.tag == "Player")
        {
            // Update player invincibility
            isInvincible = true;
            SoundManager.SoundManagerInstance.PlayClip("Power Up");
           
            // Start coroutine which determines length of invincibility
            StartCoroutine(SetVincibility());
        }
        else if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Power")
        {
            // If it isn't the player, destroy the object
            Destroy(gameObject);
        }
    }

    // Co-Routine: Used to set the invincibility of the player based on time
    public IEnumerator SetVincibility()
    {
        yield return new WaitForSeconds(invincibilityTimer);
        isInvincible = false;
        Destroy(gameObject);
    }
}
