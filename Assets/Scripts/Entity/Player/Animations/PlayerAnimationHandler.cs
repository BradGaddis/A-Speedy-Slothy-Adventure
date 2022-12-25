using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationHandler : MonoBehaviour
{

    [SerializeField]
    List<Sprite> walkSprites = new List<Sprite>();
    [SerializeField]
    List<Sprite> runSprites = new List<Sprite>();
    [SerializeField]
    List<Sprite> jumpSprites = new List<Sprite>();
    [SerializeField]
    [Header("Animation Speeds | Frames Per Second")]
    float walkAnimationSpeed;
    [SerializeField] 
    float runAnimationSpeed;
    [SerializeField]
    float jumpAnimationSpeed;
    CheckPlayerCollision checkPlayerCollision;
    float dirFacing = 1f;

    // component references
    PlayerInput playerInput;
    PlayerStateType playerStateType;
    SpriteRenderer spriteRenderer;
    PlayerAudioHandler playerAudioHandler;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = walkSprites[0];
        playerAudioHandler = GetComponent<PlayerAudioHandler>();
        checkPlayerCollision = GetComponent<CheckPlayerCollision>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        playerStateType = GetComponent<PlayerState>().GetCurState();

        switch (playerStateType)
        {
            case PlayerStateType.Walk:
                HandleWalkAnimation();
                break;
            case PlayerStateType.Run:
                HandleRunAnimation();
                break;
            case PlayerStateType.Jump:
                // Do nothing
                break;
            default:
                break;
        }
        if (playerInput.GetMovementVector().x != dirFacing)
        {
            // Remove Later
            FlipSprite();
            dirFacing = playerInput.GetMovementVector().x;
        }

    }
    private void HandleRunAnimation()
    {
        if (playerInput.GetMovementVector().x != 0)
        {
            if (checkPlayerCollision.IsGrounded()) Animate(runSprites, runAnimationSpeed);

            
        }
    }

    private void HandleWalkAnimation()
    {
        bool isWalking = playerInput.GetMovementVector().x != 0;
        if (isWalking)
        {
            if (checkPlayerCollision.IsGrounded()) {
                Animate(walkSprites, walkAnimationSpeed);
                // Play walk sound
                playerAudioHandler.PlayWalkSound(isWalking);
            }

        }
    }

    // Updates the sprite renderers sprite to the next sprite in the list
    public void Animate(List<Sprite> sprites, float animationSpeed)
    {
        int curSprite = (int)(Time.time * animationSpeed) % sprites.Count;
        spriteRenderer.sprite = sprites[curSprite];
    }


    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerInput.GetMovementVector().x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerInput.GetMovementVector().x), 1f);
        }
    }
}
