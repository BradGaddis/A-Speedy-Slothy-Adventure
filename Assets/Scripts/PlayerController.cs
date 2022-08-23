using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // component references 
    Rigidbody2D playerRb;
    BoxCollider2D boxCollider2D;
    CheckWallCollision checkWallCollision;
    PlayerAudioHandler playAudio;


    [SerializeField] float speed;  
    [SerializeField] float jumpForce;
    float dirCollided = 0;
    [SerializeField] LayerMask groundMask;
  
    [SerializeField] ParticleSystem walkDust;
    float xInput;
    float yInput;
    float lowerBound;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        checkWallCollision = GetComponent<CheckWallCollision>();
        playAudio = GetComponent<PlayerAudioHandler>();
        
        GameObject ground = GameObject.Find("Ground");
        lowerBound = ground.GetComponent<CompositeCollider2D>().bounds.min.y;
        Debug.Log(lowerBound);
    }
    private void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Jump");
        HandleMovement();
        CheckLowerBounds();
    }

    void HandleMovement(){
        Vector3 pos = transform.position;
        
        xInput *= speed;
        yInput *= jumpForce;

        playAudio.Run(IsGrounded(), (xInput != 0 && !checkWallCollision.isColliding));
        
        if(xInput != 0) {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            playerRb.velocity = new Vector2(xInput, playerRb.velocity.y);
            
            if (checkWallCollision.isColliding)
            {
                if(dirCollided == xInput) return;
                if(dirCollided != xInput)
                    dirCollided = xInput;
                playAudio.Collide();
            } 
            else {
                dirCollided = 0;
                walkDust.Play();
            }
        } else {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        } 
        if (yInput > 0 && IsGrounded()) {
            walkDust.Stop();
            playerRb.velocity = new Vector2(playerRb.velocity.x, yInput);
            playAudio.Jump();
        } 
    }

    public bool IsGrounded()
    {
        float checkDist = .1f;
        Vector2 size = boxCollider2D.bounds.size;
        RaycastHit2D raycast2D = Physics2D.BoxCast(boxCollider2D.bounds.center, size ,0,Vector2.down, checkDist, groundMask);
        return raycast2D.collider != null;
    }

    void DeathReload(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name.ToString());
    }

    void CheckLowerBounds(){
        if (transform.position.y <= lowerBound) {
            DeathReload();
        }
    }

}
