using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    private int direction = 1;
    private Vector3 initialScale;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCat();
    }

    private void OnTriggerEnter(Collider collision) 
    {
        // If the cat collides with another other gameObject with a collider
        if (collision.gameObject.tag != "Player") 
        {
            // Change the the direction the cat should be moving in
            direction = -direction;
            // Vector3 move = new Vector3(-1 * direction,0,0) * speed * Time.fixedDeltaTime;
            // rb.MovePosition(rb.position + move);
        }
    }

    // Method: Moves cat along axis
    private void moveCat()
    {
        Vector3 move = new Vector3(-1 * direction, 0, 0)* speed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.LookRotation(move);
        rb.MovePosition(rb.position + move);
    }
}
