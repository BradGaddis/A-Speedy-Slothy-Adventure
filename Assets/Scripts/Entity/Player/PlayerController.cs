// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

//     public enum PlayerChargedState {
//         baseCharge,
//         energized
//     }
    
//     public class PlayerController : MonoBehaviour
//     {
//         // component references 
//         Rigidbody2D playerRb;
//         BoxCollider2D boxCollider2D;
//         CheckWallCollision checkWallCollision;
//         PlayerAudioHandler playAudio;
//         PowerUp powerUp;
//         // PowerUpType powerUpType = PowerUpType.none;


//         [SerializeField] float speed;  
//         [SerializeField] float jumpForce;
//         float dirCollided = 0;
//         [SerializeField] LayerMask groundMask;
    
//         [SerializeField] ParticleSystem walkDust; // Move to animation handler?
//         float xInput;
//         float yInput;
//         float lowerBound;
//         [SerializeField]PlayerMoveState moveState = PlayerMoveState.idle;

//         private void Update() {
//             CheckLowerBounds();
//         }

//         void HandleMovement()
//         {
//             Vector3 pos = transform.position;
//             xInput *= speed;
//             yInput *= jumpForce;

//             playAudio.Run(IsGrounded(), (xInput != 0 && !checkWallCollision.isColliding));
            
//             // Player is running
//             if(xInput != 0) {
//                 playerRb.velocity = new Vector2(0, playerRb.velocity.y);
//                 playerRb.velocity = new Vector2(xInput, playerRb.velocity.y);
                
//                 if (checkWallCollision.isColliding)
//                 {
//                     SetPlayerState(PlayerMoveState.colliding);

//                     if(dirCollided == xInput) return;
//                     if(dirCollided != xInput)
//                         dirCollided = xInput;
//                     // playAudio.Collide();
//                 } 
//                 else {
//                     SetPlayerState(PlayerMoveState.running);

//                     dirCollided = 0;
//                     walkDust.Play();
//                 }
//             } else {
//                 SetPlayerState(PlayerMoveState.idle);
//                 playerRb.velocity = new Vector2(0, playerRb.velocity.y);
//             } 

//             // Player is jumping
//             if (yInput > 0 && IsGrounded()) {
//                 SetPlayerState(PlayerMoveState.jumping);

//                 walkDust.Stop();
//                 playerRb.velocity = new Vector2(playerRb.velocity.x, yInput);
//                 // playAudio.Jump();
//             } 
//         }

//         // TODO: make this a coroutine
//         public bool IsGrounded()
//         {
//             // float checkDist = .1f;
//             // Vector2 size = boxCollider2D.bounds.size;
//             // RaycastHit2D raycast2D = Physics2D.BoxCast(boxCollider2D.bounds.center, size ,0,Vector2.down, checkDist, groundMask);
//             // return raycast2D.collider != null;
//             return Physics2D.IsTouchingLayers(boxCollider2D,groundMask);
//         }


        
//     }
    
// }