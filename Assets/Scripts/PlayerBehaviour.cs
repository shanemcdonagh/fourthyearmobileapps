using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;
    private Rigidbody rb;

    // Status can be accessed by other classes
    public static bool isPlayerDead = false;

    public static GameObject Player;
    
    void Awake()
    {
        // Initialize rigidbody type and GameObject from current GO this script is attached to (player)
        Player = this.gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // When script is loaded, ensure player death status is set to false
        isPlayerDead = false;
    }

    private void FixedUpdate() 
    {
        // First, check if the player still is alive (has health remaining)
        if(!isPlayerDead)
        {
            Vector3 moveForward = transform.forward * playerSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveForward);
        } 
    }
    
    // Update is called once per frame
    void Update()
    {
        // Process player movement
        ProcessPlayerMovement();
    }

    // Method: When invoked, proceeds to handle players movement
    private void ProcessPlayerMovement()
    {
        // First, check if the player still is alive (has health remaining)
        if(isPlayerDead)
        {
            // If the player is dead, exit the method
            return;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Move the player position to the right
            this.transform.Translate(0.5f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Move the player position to the right
            this.transform.Translate(-0.5f, 0f, 0f);
        }
    }
}
