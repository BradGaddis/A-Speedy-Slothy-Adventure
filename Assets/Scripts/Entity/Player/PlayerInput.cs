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
    PlayerState playerState;

    float speed;
    [SerializeField]
    float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        checkPlayerCollision = GetComponent<CheckPlayerCollision>();
        rb = GetComponent<Rigidbody2D>(); 
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update() {
        DebugUltil.DebugUltil.CheckComponents(this.gameObject);
        speed = stats.speed;
        jumpForce = stats.jumpForce;

        Vector2 movement = GetMovementVector();
        HandleStates(movement);
        HandleHorizontalMovement(movement);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void HandleStates(Vector2 movement) {
        // Update state if player is jumping or falling
        if (!checkPlayerCollision.IsGrounded())
        {
            playerState.SetState(PlayerStateType.Jump);
        }
        else if (playerState.GetCurState() == PlayerStateType.Jump)
        {
            playerState.SetState(PlayerStateType.Fall);
        }
        else
        {
            // Update state if player is moving
            if (movement.x != 0)
            {
                if (playerState.GetPoweredUp()) playerState.SetState(PlayerStateType.Run); // TODO this should be whatever state the powerup is in
                else playerState.SetState(PlayerStateType.Walk);
            }
            else
            {
                playerState.SetState(playerState.GetPrevState());
            }
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

    void Jump()
    {   

        if(!checkPlayerCollision.IsGrounded()) return;
        
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }
}

