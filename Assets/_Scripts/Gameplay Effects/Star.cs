using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Reference: https://answers.unity.com/questions/700255/powerup-script-to-make-player-invincible.html
public class Star : MonoBehaviour
{
    public static bool isInvincible = false;
    [SerializeField] private float invincibilityTimer = 3.0f;

    // Activates when the something collides with the cheese
    private void OnTriggerEnter(Collider other) 
    {
        // Prevent stacking objects
        if(other.gameObject.tag == "Player")
        {
            // Update player invincibility
            isInvincible = true;
            SoundManager.SoundManagerInstance.PlayClip("Power Up");
           
            StartCoroutine(SetVincibility());  
        }
    }

    public IEnumerator SetVincibility()
    {
        yield return new WaitForSeconds(invincibilityTimer);
        isInvincible = false;
        Destroy(gameObject);
    }
}
