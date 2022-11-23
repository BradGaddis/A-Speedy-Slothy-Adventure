using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "stats/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float speed;
    public float jumpForce;
}