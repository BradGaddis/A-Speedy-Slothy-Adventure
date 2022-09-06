using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : DamageZone
{
    public override void DealDamage(float dmg) {

        health.currentHealth -= dmg;
    }
    
    public bool HasTouchDamage() {
        return this.hasTouchDamage;
    }

    public float GetTouchDamage() {
        return this.touchDamage;
    }

}
