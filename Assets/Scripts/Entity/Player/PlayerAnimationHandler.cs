using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sloth.Entity.Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] List<Sprite> runAnimationSprites;
        [SerializeField] List<Sprite> idleAnimationSprites;
        SpriteRenderer spriteRenderer;
        [SerializeField] float runAnimFR;
        [SerializeField] float idleAnimFR;
        Rigidbody2D rb;
        // Dictionary<string, float> stats;
        PlayerController playerController;
        float xmoveDir;

        private void Start() {
            playerController = GetComponent<PlayerController>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        void Update()
        {
            // Determine if we are even moving
            // stats = GetComponent<PlayerController>().GetStats();
            xmoveDir = Input.GetAxisRaw("Horizontal");
            switch (GetPlayerState())
            {
                case PlayerMoveState.running:
                HandleRunning();
                break;

                case PlayerMoveState.idle:
                HandleIdle();
                break;

                case PlayerMoveState.jumping:
                HandleJump();
                break;

                default:
                HandleIdle();
                break;
            }
            GetPlayerState();
        }

        void HandleIdle() {
            if (xmoveDir == 0) {
                int frame = (int)((Time.time + (Time.time * idleAnimFR)) % idleAnimationSprites.Count);
                spriteRenderer.sprite = idleAnimationSprites[frame];
            }
        }

        void HandleRunning() {
            if (xmoveDir != 0) {
                int frame = (int)((Time.time + (Time.time * Mathf.Abs(rb.velocity.x)))  % runAnimationSprites.Count);
                spriteRenderer.sprite = runAnimationSprites[frame]; 
            } 

            FlipSprite(xmoveDir);
        }

        void HandleJump() {

        }

        void FlipSprite(float dir) {
            if(dir > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
            } 
            else if(dir < 0 && transform.localScale.x > 0) 
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
            } 
        }


        PlayerMoveState GetPlayerState() {
            PlayerMoveState state = playerController.GetPlayerState();
            return state;
        }
    }
}


