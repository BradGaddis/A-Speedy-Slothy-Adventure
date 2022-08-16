using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;  
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundMask;
    [SerializeField] AudioClip jumpSfx;
    AudioSource audioSource;

    Rigidbody2D playerRb;
    BoxCollider2D boxCollider2D;
    float xInput;
    float yInput;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Jump");
    }  
    void FixedUpdate()
    {
        HandleMovement();

    }

    void HandleMovement(){
        Vector3 pos = transform.position;
        
        xInput *= speed;
        yInput *= jumpForce;
        // Debug.Log(xInput);
        Debug.Log(yInput);

        if(xInput != 0) {
            playerRb.velocity = new Vector2(xInput, playerRb.velocity.y);
        } else {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        } 
        if (yInput > 0 && IsGrounded()) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, yInput);
            audioSource.PlayOneShot(jumpSfx);
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
