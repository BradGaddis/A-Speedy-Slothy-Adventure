using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sloth.Entity.Player {
    public class CheckPlayerDamage : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other) {
            // check if touch damage
            
            if(other.gameObject.GetComponent<DamageZone>() != null)
                {
                    Debug.Log(other.gameObject.name + " was hit");
                }
            else {
                Debug.Log("This didn't work");
            }
                
        }
        
    }
    
}