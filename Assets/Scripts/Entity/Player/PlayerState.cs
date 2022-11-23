using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerStates {
    idle,
    running,
    jumping,
    falling,
    colliding
}

[System.Serializable]
public class PlayerStateHandler 
{
    playerStates currentState;

    public void SetPlayerState(playerStates newState) {
        currentState = newState;
    }

    public playerStates GetPlayerState() {
        return currentState;
    }
}

// I'ma just make it simple til I figure out what the hell I'm tryna do
// Thanks copilot!
