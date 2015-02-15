using UnityEngine;
using System.Collections;

public class MobilityComponent : MonoBehaviour {
    [Tooltip("Speed at which the entity moves")]
    public float Speed = 1.0f;
    [Tooltip("Whether or not the entity is able to move")]
    public bool Moveable = true;
    [Tooltip("Whether or not the entity should be facing in the direction they are moving")]
    public bool RotateWithMovement = true;
}
