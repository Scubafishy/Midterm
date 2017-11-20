using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    Animator anim;


    private AudioSource audioSource;
    private bool isOnGround = false;
    private bool isJumpPad = false;
    private bool shouldJump = false;
    Rigidbody2D myRigidbody;
    private float horizontalInput;
    private Vector2 jumpForce;
    private bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        

        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        jumpForce = new Vector2(0, jumpStrength);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
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
        anim.SetBool("Ground", isOnGround);
        anim.SetFloat("vSpeed", myRigidbody.velocity.y);
        anim.SetBool("Death", false);
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
            audioSource.Play();
        }
    }

    private void Move()
    {
        myRigidbody.velocity =
            new Vector2(horizontalInput * movementSpeed, myRigidbody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
