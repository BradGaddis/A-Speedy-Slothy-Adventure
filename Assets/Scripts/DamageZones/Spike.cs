using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : DamageZone
{
    public override void DealDamage(float dmg) {

        health.currentHealth -= dmg;
    }
   
}
