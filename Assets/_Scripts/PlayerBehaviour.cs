using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float playerSpeed = 7.0f;
    [SerializeField] float jumpAmt;
    [SerializeField] LayerMask plane;
    private Rigidbody rb;

    // Status can be accessed by other classes
    public static bool isPlayerDead = false;

    public static GameObject Player;
    private int distanceTravelled = 0;


    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI gameOverDistanceText;

    
    void Awake()
    {
        // Initialize rigidbody type and GameObject from current GO this script is attached to (player)
        Player = this.gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating("getDistance",0, 1 / playerSpeed);
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

        if(Input.GetKeyDown(KeyCode.D))
        {
            // Move the player position to the right
            this.transform.Translate(0.5f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            // Move the player position to the right
            this.transform.Translate(-0.5f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            jump();   
        }
    }

    private void jump()
    {
        // Firstly, check if the player is currently on the ground
        // Reference: https://youtu.be/x-EtYggJdP0

        // Retrieve the players center of origin
        float playerHeight = GetComponent<Collider>().bounds.size.y;

        // Cast a ray downwards to players feet to see if it's touching the floor
        //bool onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f, plane);

        if(Mathf.Floor(this.transform.position.y) == 1)
        {
            rb.AddForce(Vector3.up * jumpAmt);
            SoundManager.SoundManagerInstance.PlayClip("Jump");
        }
    }

    // Reference: https://youtu.be/53ATbkNrHjw
    private void getDistance()
    {
        distanceTravelled = distanceTravelled + 1;

        distanceText.text = distanceTravelled.ToString() + "m";
        gameOverDistanceText.text = distanceTravelled.ToString() + "m";
    }

    private void increaseSpeed()
    {
        int currentLevel = GameObject.FindObjectOfType<GameBehaviour>().GetLevel();

        // Ensures that these if-else statements don't execute continously by checking if playerSpeed is already set to new speed
        if(currentLevel == 2 && playerSpeed != 15.0f)
        {
            // Update player speed to 10
            playerSpeed = 15.0f;
            
            StartCoroutine(GameObject.FindObjectOfType<UIControls>().NewLevelText("Level 2"));
           
        }
        else if(currentLevel == 3 && playerSpeed != 20.0f)
        {
            // Update player speed to 12
            playerSpeed = 20.0f;

            StartCoroutine(GameObject.FindObjectOfType<UIControls>().NewLevelText("Level 3"));
        }
    }
}
