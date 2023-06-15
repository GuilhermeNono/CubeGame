using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private BoxCollider2D collider;
    private bool hasKey = false; 

    [SerializeField]
    private LayerMask jumpableGround;
    
    private float speedPlayer = 10f;
    [SerializeField]
    private int jumpCount = 2;
    [SerializeField]
    private bool canJump = true;

    private bool canMove = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        JumpPlayer();
    }

    void MovementPlayer()
    {
        float dirX = Input.GetAxis("Horizontal");
        if (canMove)
        {
            rigidBody.velocity = new Vector2(dirX * speedPlayer, rigidBody.velocity.y);
        }
    }

    void JumpPlayer()
    {
        if (jumpCount == 0)
        {
            jumpCount = 2;
            canJump = false;
        } else
        if (Input.GetButtonDown("Jump") && canJump)
        {
            jumpCount--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 10);
        }

        if (IsGrounded())
            canJump = true;
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center,
            collider.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround);
    }

    public void disableMovement()
    {
        canMove = false;
        canJump = false;
    }

    public void gotTheKey()
    {
        hasKey = true;
    }

    public bool hasTheKey()
    {
        return hasKey;
    }
}
