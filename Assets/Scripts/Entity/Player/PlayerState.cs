// This class is the base class for all player states
// This class keeps track of the player's current state, as well as the player's previous state, and the player's next state. It also sets the player's state

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType 
{
    Idle,
    Walk,
    IdleRun,
    Run,
    Jump,
    Fall,
    Attack,
    Hurt,
    Dead
}

public class PlayerState : MonoBehaviour {
    private PlayerStateType currentState = PlayerStateType.Idle;
    private PlayerStateType previousState = PlayerStateType.Idle;
    public PlayerStateType CurrentState { get => currentState; }
    public PlayerStateType PreviousState { get => previousState; }

    float waitTilIdle;
    [SerializeField]
    float idleWaitTime = 1f;

    bool isPoweredUp;

    private void Start() {
        waitTilIdle = Time.time + idleWaitTime;
    }

    private void Update() {
        // Debug.Log("Current state: " + currentusState);
    }

    public void SetState(PlayerStateType newState) {
        previousState = currentState;
        currentState = newState;
    }

    public PlayerStateType GetCurState() {
        return CurrentState;
    }

    public PlayerStateType GetPrevState() {
        return PreviousState;
    }

    public void SetPoweredUp(bool isPoweredUp) {
        this.isPoweredUp = isPoweredUp;
    }

    // This code is ugly as hell and I'm sorry. I'll fix it later
    public void HandleStates(Vector2 movement, bool isFalling, bool isGrounded) {
        // Update state if player is jumping or falling
        Debug.Log("Current state: " + CurrentState);
        if (isFalling)
        {
            SetState(PlayerStateType.Fall);
        }
        else if (!isGrounded)
        {
            SetState(PlayerStateType.Jump);
        }
        else
        {
            // Update state if player is moving
            if (movement.x != 0)
            {
                if (isPoweredUp)
                {
                    SetState(PlayerStateType.Run);
                }
                else
                {
                    SetState(PlayerStateType.Walk);
                }
            }
            else
            {
                // wait some time, then set back to idle
                if (Time.time >= waitTilIdle)
                {
                    SetState(PlayerStateType.Idle);
                    waitTilIdle = Time.time + idleWaitTime;
                } 
            }
        }
    }
}