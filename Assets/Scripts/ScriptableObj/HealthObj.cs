using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "stats/health" , fileName = "New Health")]
public class HealthObj : ScriptableObject
{
    [SerializeField]
    static float maxHealth = 100;
    [SerializeField] 
    float currentHealth = maxHealth;

    public float GetCurrentHealth(){
        return currentHealth;
    }
}
