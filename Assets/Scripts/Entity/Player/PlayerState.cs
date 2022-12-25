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
    private PlayerStateType currentState;
    private PlayerStateType previousState;
    public PlayerStateType CurrentState { get => currentState; set => currentState = value; }
    public PlayerStateType PreviousState { get => previousState; }

    bool isPoweredUp;

    private void Start() {
        currentState = PlayerStateType.Idle;
        previousState = PlayerStateType.Idle;
        isPoweredUp = false;
    }

    public void SetState(PlayerStateType newState) {
        previousState = currentState;
        currentState = newState;
    }

    public PlayerStateType GetCurState() {
        Debug.Log("Current State: " + currentState);
        return currentState;
    }

    public PlayerStateType GetPrevState() {
        Debug.Log("Previous State: " + previousState);
        return previousState;
    }

    public void SetPoweredUp(bool isPoweredUp) {
        this.isPoweredUp = isPoweredUp;
    }

    public bool GetPoweredUp() {
        return isPoweredUp;
    }
}