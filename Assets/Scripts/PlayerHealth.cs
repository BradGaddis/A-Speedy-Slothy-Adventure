using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    HealthObj healthObj;
    [SerializeField]
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        slider.value = GetPlayerHealth();
    }

    void SetPlayerHealth(float dmg) {
        healthObj.currentHealth -= dmg;
    }

    public float GetPlayerHealth() {
        return healthObj.currentHealth;
    }

}
