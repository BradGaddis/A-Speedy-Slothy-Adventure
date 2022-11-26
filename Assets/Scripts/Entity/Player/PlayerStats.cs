using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Stats/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public float speed;
    public float jumpForce;
}
