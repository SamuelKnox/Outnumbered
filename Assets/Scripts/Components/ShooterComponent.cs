using UnityEngine;
using System.Collections;

public class ShooterComponent : MonoBehaviour {
    [Tooltip("Offset from the entity where the ammunition spawns")]
    public Vector2 SpawnOffset;
    [Tooltip("Speed at which the ammunition leaves the shooter")]
    public float Speed = 1.0f;
    [Tooltip("Direction in which the ammunition will travel.  If Vector2.zero, the ammunition will travel in the direction that the entity is facing.")]
    public Vector2 Direction = Vector2.zero;
    [Tooltip("Rate in seconds at which the entity is able to fire")]
    public float RateOfFire = 1.0f;
}
