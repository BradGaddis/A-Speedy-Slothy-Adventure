using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sloth.Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] List<Sprite> runAnimationSprites;
        [SerializeField] List<Sprite> idleAnimationSprites;
        SpriteRenderer spriteRenderer;
        [SerializeField] float runAnimFR;
        Rigidbody2D rb;
        Dictionary<string, float> stats;


        private void Start() {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        void Update()
        {
            // Determine if we are even moving
            stats = GetComponent<PlayerController>().GetStats();
            float xmoveDir = Input.GetAxisRaw("Horizontal");
            if (xmoveDir != 0) {
                HandleRunning();
                FlipSprite(xmoveDir);
            } 
        }

        void HandleIdle() {

        }

        void HandleRunning() {
            int frame = (int)((Time.time + (Time.time * Mathf.Abs(rb.velocity.x)))  % runAnimationSprites.Count);
            spriteRenderer.sprite = runAnimationSprites[frame]; 
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
    }
}


