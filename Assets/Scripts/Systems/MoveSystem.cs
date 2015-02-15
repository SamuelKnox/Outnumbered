using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MobilityComponent))]
public class MoveSystem : MonoBehaviour
{
    private MobilityComponent mobilityComponent;

    void Start()
    {
        mobilityComponent = GetComponent<MobilityComponent>();
    }
    /// <summary>
    /// Moves gameObject based on the parameters of horizontal axis, vertical axis, and speed
    /// </summary>
    public void Move(float horizontalAxis, float verticalAxis)
    {
        Vector2 movement = Vector2.zero;
        if (mobilityComponent.Moveable)
        {
            movement = new Vector2(horizontalAxis, verticalAxis);
            movement *= mobilityComponent.Speed;
        }
        rigidbody2D.velocity = movement;
        if (mobilityComponent.RotateWithMovement)
        {
            RotatePlayerInDirectionOfMovement(movement);
        }
    }

    /// <summary>
    /// Rotates gameObject based on the passed in movement
    /// </summary>
    public void RotatePlayerInDirectionOfMovement(Vector3 movement)
    {
        if (rigidbody2D.velocity.sqrMagnitude > 0.01f)
        {
            rigidbody2D.fixedAngle = false;
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            rigidbody2D.fixedAngle = true;
        }
    }
}
