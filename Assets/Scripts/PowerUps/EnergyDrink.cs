// using System.Collections;
// using System.Collections.Generic;
// using Sloth.Entity.Player;
// using UnityEngine;

// public class EnergyDrink : PowerUp
// {
//     [SerializeField]
//     float speedBoost,jumpBoost;

//     void PowerUpPlayer(Collider2D other){
//         // give the player extra stats
//         // PlayerController player = other.gameObject.GetComponent<PlayerController>();
//         player.ChangeStats(speedBoost,jumpBoost);
//     }
    
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if(other.gameObject.tag == "Player")
//         {
//             Debug.Log($"Got the power {this.gameObject.name}");
//             PowerUpPlayer(other);
//             Destroy(gameObject);
//         }
//     }
// }
