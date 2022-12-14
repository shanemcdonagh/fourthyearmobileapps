using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class: Provides the movement for the enemy moving Cat type
public class CatController : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    private int direction = 1;
    private Vector3 initialScale;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the current gameObjects rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Invoke the method which moves the rigidbody
        moveCat();
    }

    // Method: Triggered when gameObject collides with another gameObject with a collider
    private void OnTriggerEnter(Collider collision) 
    {
        // If the cat collides with another gameObject with a collider that isn't the player
        if (collision.gameObject.tag != "Player") 
        {
            // Change the the direction the cat should be moving in
            direction = -direction;
        }
    }

    // Method: Moves cat along axis
    private void moveCat()
    {
        // Movement values we will set on the rigidbody
        Vector3 move = new Vector3(-1 * direction, 0, 0)* speed * Time.fixedDeltaTime;

        // Ensures cat model faces direction they are moving
        transform.rotation = Quaternion.LookRotation(move);

        // Move the gameObject
        rb.MovePosition(rb.position + move);
    }
}
