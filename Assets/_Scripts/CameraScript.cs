using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Create an offset based on the distance between the player and the camera
        offset = transform.position - PlayerBehaviour.Player.transform.position;
    }

    void LateUpdate()
    {
        // Retrieve the current position of the player with an offset
        Vector3 position = PlayerBehaviour.Player.transform.position + offset;
        
        // Set the x value to 0 so the camera remains centered
        position.x = 0;

        // Set camera position
        transform.position = position;
    }
}
