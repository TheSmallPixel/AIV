using UnityEngine;


[CreateAssetMenu(fileName = "game", menuName = "mygame/playerStats")]
public class PlayerStats : ScriptableObject
{
    [Range(0.1f, 10f)]
    public float PlayerVelocity;
}
