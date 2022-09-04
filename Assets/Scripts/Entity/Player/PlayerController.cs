using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sloth.Player
{
    public enum PlayerMoveState {
        idle,
        running,
        colliding,
        jumping,
    }

    public enum PlayerChargedState {
        baseCharge,
        energized
    }
    public class PlayerController : MonoBehaviour
    {
        // component references 
        Rigidbody2D playerRb;
        BoxCollider2D boxCollider2D;
        CheckWallCollision checkWallCollision;
        PlayerAudioHandler playAudio;
        PowerUp powerUp;


        [SerializeField] float speed;  
        [SerializeField] float jumpForce;
        float dirCollided = 0;
        [SerializeField] LayerMask groundMask;
    
        [SerializeField] ParticleSystem walkDust;
        float xInput;
        float yInput;
        float lowerBound;
        PlayerChargedState energyState;
        [SerializeField]PlayerMoveState moveState = PlayerMoveState.idle;

        private void Start() {
            playerRb = GetComponent<Rigidbody2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            checkWallCollision = GetComponent<CheckWallCollision>();
            playAudio = GetComponent<PlayerAudioHandler>();
            powerUp = GetComponent<PowerUp>();
            
            GameObject ground = GameObject.Find("Ground");
            lowerBound = ground.GetComponent<CompositeCollider2D>().bounds.min.y;
            // TODO GET THIS FROM CAMERA

            energyState = PlayerChargedState.baseCharge;
        }
        private void Update() {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Jump");
            HandleMovement();
            CheckLowerBounds();
        }

        void HandleMovement()
        {
            Vector3 pos = transform.position;
            xInput *= speed;
            yInput *= jumpForce;

            playAudio.Run(IsGrounded(), (xInput != 0 && !checkWallCollision.isColliding));
            
            // Player is running
            if(xInput != 0) {
                playerRb.velocity = new Vector2(0, playerRb.velocity.y);
                playerRb.velocity = new Vector2(xInput, playerRb.velocity.y);
                
                if (checkWallCollision.isColliding)
                {
                    SetPlayerState(PlayerMoveState.colliding);

                    if(dirCollided == xInput) return;
                    if(dirCollided != xInput)
                        dirCollided = xInput;
                    // playAudio.Collide();
                } 
                else {
                    SetPlayerState(PlayerMoveState.running);

                    dirCollided = 0;
                    walkDust.Play();
                }
            } else {
                playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            } 

            // Player is jumping
            if (yInput > 0 && IsGrounded()) {
                SetPlayerState(PlayerMoveState.jumping);
                
                walkDust.Stop();
                playerRb.velocity = new Vector2(playerRb.velocity.x, yInput);
                // playAudio.Jump();
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
        public PlayerChargedState GetEnergyState(){
            return energyState;
        }
        public void SetChargedState(PlayerChargedState state) {
            energyState = state;
        }

        public PlayerMoveState GetPlayerState(){
            return moveState;
        }
        
        public void SetPlayerState(PlayerMoveState newState) {
            moveState = newState;
        }


        public void ChangeStats(float newSpeed = 0, float newJump = 0) {

            if(newSpeed != 0){
                speed = newSpeed;
            }
            if(newJump != 0)
            {
                jumpForce = newJump; 
            } 
            else{
                Debug.LogError("No attributes set");
            }
        }
        public Dictionary<string, float> GetStats() {
            Dictionary<string, float> output = new Dictionary<string, float>();
            output.Add("speed", speed);
            output.Add("jump", jumpForce);
            return output;
        }
    }
}