using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DebugUltil;


public class PlayerInput : MonoBehaviour
{
    // componenet references
    Rigidbody2D rb;
    [SerializeField] PlayerStats stats;
    [SerializeField] PlayerStats prevStats;
    CheckPlayerCollision checkPlayerCollision;
    Vector2 movement;

    float speed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float jumpCoolDown = 0.5f;
    float jumpTimer;
    public bool didJump { get; private set;}
    public bool isFalling { get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        checkPlayerCollision = GetComponent<CheckPlayerCollision>();
        rb = GetComponent<Rigidbody2D>(); 
        jumpTimer = jumpCoolDown;
    }

    // Update is called once per frame
    void Update() {
        speed = stats.speed;
        jumpForce = stats.jumpForce;
        bool isGrounded = checkPlayerCollision.IsGrounded();

        Vector2 movement = GetMovementVector();
        HandleHorizontalMovement(movement);

        // if gounded, start timer, then allow jump
        
        jumpCoolDown -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            Jump(isGrounded);
        }



        // Check if player is falling
        if (rb.velocity.y < 0) {
            didJump = false;
            isFalling = true;
        } else {
            isFalling = false;
        }
    }

    public Vector2 GetMovementVector()
    {
        float x = Input.GetAxisRaw("Horizontal");
        // float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, 0);
    }

    void HandleHorizontalMovement(Vector2 movement)
    {
        // update velocity maintaining y velocitiy
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    void Jump(bool isGrounded)
    {   
        if (jumpCoolDown > 0) return;
        jumpCoolDown = jumpTimer;
        if(!isGrounded ) return;
        didJump = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}

