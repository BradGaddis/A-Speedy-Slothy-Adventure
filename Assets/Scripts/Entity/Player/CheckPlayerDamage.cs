using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sloth.Entity.Player {
    public class CheckPlayerDamage : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D other) {
            // check if touch damage
            DamageZone zone; 

            if(other.gameObject.GetComponent<DamageZone>() != null)
                {
                    Debug.Log(other.gameObject.name + " was hit");
                    
                    zone = other.gameObject.GetComponent<DamageZone>();
                    if(zone.HasTouchDamage())
                    {
                        zone.DealDamage(zone.GetTouchDamage());
                    }
                
                }
        }
        
    }
    
}