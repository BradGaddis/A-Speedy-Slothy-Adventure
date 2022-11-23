using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // component references 
    Rigidbody2D playerRb;
    BoxCollider2D boxCollider2D;

    [SerializeField] 
    // Player stats
    PlayerStats playerStats;
    float xInput;
    float yInput;
    LayerMask groundMask;
    PlayerStateHandler playerStateHandler;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerStateHandler = GetComponent<PlayerStateHandler>();
    }

    private void Update() {
        Vector2 MoveDir = GetMovement();
        if (MoveDir != Vector2.zero) {
            HandleWalk(MoveDir);
        }
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    Vector2 GetMovement() {
        xInput = Input.GetAxisRaw("Horizontal");
        return new Vector2(xInput, yInput).normalized;
    }

    void HandleWalk(Vector2 MoveDir) {
        playerRb.velocity = new Vector2(MoveDir.x * playerStats.speed, playerRb.velocity.y);
    }

    void Jump() {
        playerRb.velocity = new Vector2(playerRb.velocity.x, playerStats.jumpForce);
    }

    bool IsGrounded() {
        // Raycast from the center of the player to the bottom of the player
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundMask);
        return raycastHit2D.collider != null;
    }
}
