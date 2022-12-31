using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Speed,
    Jump,
    Health,
    Damage
}

public class PowerUp : MonoBehaviour
{
    // public PowerUpType powerUpType;
    public float powerUpDuration;
    public float powerUpValue;
    public float powerUpTimer;
    public bool powerUpActive;
    public bool powerUpExpired;

    // Get the player's current state
    PlayerState playerState;
    [SerializeField]
    PowerUpType thisType;

    // Attributes to boost player stats depending on powerup type
    [SerializeField]
    protected float speedBoost;
    [SerializeField]
    protected float jumpBoost;
    [SerializeField]
    protected float healthBoost;
    [SerializeField]
    protected float damageBoost;



    // if player collects, destroy powerup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check powerup type
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivatePowerUp(collision.gameObject);
            // Deactivate powerup
        }
    }

    // if player collects, activate powerup
    virtual protected void ActivatePowerUp(GameObject player) {
        // check powerup type
        playerState = player.GetComponent<PlayerState>();
        switch (thisType) {
            case PowerUpType.Speed:
                playerState.SetPoweredUp(true);
                playerState.SetState(PlayerStateType.Run);
                break;
            case PowerUpType.Jump:
                
                break;
            case PowerUpType.Health:
                
                break;
            case PowerUpType.Damage:
               
                break;
        }
        DeactivatePowerUp();
        StartCoroutine(PowerUpTimer());
    }

    // turns off sprite render and colliders
    virtual protected void DeactivatePowerUp() {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator PowerUpTimer() {
        Debug.Log("Powerup timer started");
        powerUpActive = false;
        yield return new WaitForSeconds(powerUpDuration);
        // Debug.Log("Powerup timer ended");
        playerState.SetPoweredUp(false);
        powerUpExpired = true;
        Destroy(this.gameObject);
    }
}



