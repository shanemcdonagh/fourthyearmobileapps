using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private int direction = -1;
    private Vector3 initialScale;
    private Rigidbody2D rb;
    
    // Method: Invoked on object instantiation (before Start())
    private void Awake()
    {
        initialScale = transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCat();
    }

    private void OnTriggerEnter(Collider other) 
    {
        // If the cat collides with another other gameObject with a collider
        if (other.gameObject.GetComponent<PlayerBehaviour>() == null) 
        {
            // Change the the direction the cat should be moving in
            direction = -direction;
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
        }
    }

    // Method: Moves cat along axis
    private void moveCat()
    {
        // Retrieve the current position of the cat
        Vector2 position = rb.position;
        
        // Increase the cat on the x position based on speed and direction
        position.x = position.x + Time.deltaTime * speed * direction;
        
        // Move the rigidBody to the new position
        rb.MovePosition(position);
    }
}
