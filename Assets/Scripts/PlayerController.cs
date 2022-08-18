using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // component references 
    Rigidbody2D playerRb;
    AudioSource audioSource;
    BoxCollider2D boxCollider2D;
    CheckWallCollision checkWallCollision;


    [SerializeField] float speed;  
    [SerializeField] float jumpForce;
    float dirCollided = 0;
    [SerializeField] LayerMask groundMask;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip collideSFX;
    float xInput;
    float yInput;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        checkWallCollision = GetComponent<CheckWallCollision>();
    }
    private void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Jump");
    }  
    void FixedUpdate()
    {
        HandleMovement();
        // check if we collided horizontally and play sfx
    }

    void HandleMovement(){
        Vector3 pos = transform.position;
        
        xInput *= speed;
        yInput *= jumpForce;

        if(xInput != 0) {
            playerRb.velocity = new Vector2(xInput, playerRb.velocity.y);
            if (checkWallCollision.isColliding)
            {
                if(dirCollided == xInput) return;
                audioSource.PlayOneShot(collideSFX);
                dirCollided = xInput;
            } else {
                dirCollided = 0;
            }
        } else {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        } 
        if (yInput > 0 && IsGrounded()) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, yInput);
            audioSource.PlayOneShot(jumpSFX);
        } 
    }

    bool IsGrounded()
    {
        float checkDist = .1f;
        Vector2 size = boxCollider2D.bounds.size;
        RaycastHit2D raycast2D = Physics2D.BoxCast(boxCollider2D.bounds.center, size ,0,Vector2.down, checkDist, groundMask);
        return raycast2D.collider != null;
    }


}
