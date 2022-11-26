using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // componenet references
    Rigidbody2D rb;
    [SerializeField] PlayerStats stats;
    CheckPlayerCollision checkPlayerCollision;
    float speed;
    float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        checkPlayerCollision = GetComponent<CheckPlayerCollision>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        speed = stats.speed;
        jumpForce = stats.jumpForce;

        Vector2 movement = GetMovementVector();
        HandleMovement(movement);
        if(Input.GetButtonDown("Jump")){
            HandleJump();
        }
    }
    
    Vector2 GetMovementVector()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, y);
    }

    void HandleMovement(Vector2 movement)
    {
        rb.velocity = movement * speed;
    }

    void HandleJump()
    {   
        if(!checkPlayerCollision.IsGrounded()) return;
        rb.AddForce(Vector2.up * jumpForce);
    }
}

