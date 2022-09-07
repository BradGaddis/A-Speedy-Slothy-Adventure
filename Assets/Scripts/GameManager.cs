using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sloth.Entity.Player;


public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject Player;
    
    [SerializeField] PlayerMoveState playerMoveState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float GetPlayerHealth() {
        return playerHealth.GetPlayerHealth();
    }

    // public PlayerMoveState GetPlayerMove
 } 