using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Get Player Input Reference
    PlayerInput PlayerInput;
    Vector2 movement;

    // Get Player State Reference
    PlayerState playerState;
    // Get Player Collision Reference
    CheckPlayerCollision CheckPlayerCollision;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        playerState = GetComponent<PlayerState>();
        CheckPlayerCollision = GetComponent<CheckPlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = PlayerInput.GetMovementVector();
        playerState.HandleStates(movement, PlayerInput.isFalling , CheckPlayerCollision.IsGrounded());
    }
}
