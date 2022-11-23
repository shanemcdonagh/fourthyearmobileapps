using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    // Used to determine the speed in which the ground travels
    [SerializeField] float groundMoveSpeed = -0.15f;

    void FixedUpdate()
    {
        // If: The Player is currently dead
        if(PlayerBehaviour.isPlayerDead)
        {
            // Exit the method
            return;
        }

        // Retrieve player position, to determine the direction to move platform
         this.transform.position += 
            PlayerBehaviour.Player.transform.forward * groundMoveSpeed;
    }
}
