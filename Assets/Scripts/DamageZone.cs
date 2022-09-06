using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDamageable {
    void DealDamage(float dmgAmt);
}

public class DamageZone : MonoBehaviour, iDamageable
{
    [SerializeField]
    protected HealthObj health;

    [SerializeField]
    protected bool hasTouchDamage;

    [SerializeField]
    protected float touchDamage;

    public virtual void DealDamage(float damage) {

    }

}
