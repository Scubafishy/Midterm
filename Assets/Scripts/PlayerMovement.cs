using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float jumpStrength = 10;

    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    float groundDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    [SerializeField]
    Transform jumpDetectPoint;

    [SerializeField]
    float jumpDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsJumpPad;


    private AudioSource audioSource;
    private bool isOnGround = false;
    private bool isJumpPad = false;
    private bool shouldJump = false;
    Rigidbody2D myRigidbody;
    private float horizontalInput;
    private Vector2 jumpForce;

    // Use this for initialization
    void Start () {
        // This code teleports the gameobject to a new location
        //transform.position = new Vector3(0, 0, 0);

        myRigidbody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        jumpForce = new Vector2(0, jumpStrength);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        GetMovementInput();
        GetJumpInput();
        UpdateIsOnGround();
        UpdateIsOnJumpPad();
    }

    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            shouldJump = true;
        }

        if (Input.GetButtonDown("Jump") && isJumpPad)
        {
            shouldJump = true;
        }

    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Update is called once every fixed increment of time
    private void FixedUpdate()
    {
        Move();
        Jump();        
    }

    private void UpdateIsOnGround()
    {
       Collider2D[] groundObjects = Physics2D.OverlapCircleAll(
            groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);

        isOnGround = groundObjects.Length > 0;
    }
    private void UpdateIsOnJumpPad()
    {
        Collider2D[] JumpObjects = Physics2D.OverlapCircleAll(
             jumpDetectPoint.position, jumpDetectRadius, whatCountsAsJumpPad);

        isJumpPad = JumpObjects.Length > 0;
    }

    private void Jump()
    {
        if (shouldJump)
        {
            // myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpStrength);
            myRigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            isJumpPad = false;
            shouldJump = false;
           // audioSource.Play();
        }
    }

    private void Move()
    {
        myRigidbody.velocity =
            new Vector2(horizontalInput * movementSpeed, myRigidbody.velocity.y);
    }
}
