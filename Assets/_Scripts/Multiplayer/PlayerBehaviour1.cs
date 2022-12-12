using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Separate script for Player Two
public class PlayerBehaviour1 : MonoBehaviour
{
    [SerializeField] float playerSpeed = 7.0f;
    [SerializeField] float jumpAmt;
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
        increaseSpeed();
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

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {    
            jump();   
        }
    }

    private void jump()
    {
        // Firstly, check if the player is currently on the ground
        if(Mathf.Floor(this.transform.position.y) == 1)
        {
            rb.AddForce(Vector3.up * jumpAmt);
            SoundManager.SoundManagerInstance.PlayClip("Jump");
        }
    }

    private void increaseSpeed()
    {
        int currentLevel = GameObject.FindObjectOfType<GameBehaviour>().GetLevel();

        if(currentLevel == 2)
        {
            // Update player speed to 10
            playerSpeed = 15.0f;
        }
        else if(currentLevel == 3)
        {
            // Update player speed to 12
            playerSpeed = 20.0f;
        }
    }
}
