using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    [Tooltip("Offset from the entity where the ammunition spawns")]
    public Vector2 SpawnOffset;
    [Tooltip("Speed at which the ammunition leaves the shooter")]
    public float Speed = 1.0f;
    [Tooltip("Direction in which the ammunition will travel.  If Vector2.zero, the ammunition will travel in the direction that the entity is facing.")]
    public Vector2 Direction = Vector2.zero;
    [Tooltip("Rate in seconds at which the entity is able to fire")]
    public float RateOfFire = 1.0f; private float reloadTimeRemaining;

    void Start()
    {
        reloadTimeRemaining = RateOfFire;
    }

    void Update()
    {
        reloadTimeRemaining -= Time.deltaTime;
    }

    public void Shoot(GameObject ammunitionPrefab)
    {
        if (reloadTimeRemaining > 0)
        {
            return;
        }
        Vector3 ammunitionPosition = transform.position + new Vector3(transform.up.x * SpawnOffset.x, transform.up.y * SpawnOffset.y);
        GameObject ammunition = Instantiate(ammunitionPrefab, ammunitionPosition, transform.rotation) as GameObject;
        if (Direction == Vector2.zero)
        {
            ammunition.rigidbody2D.AddForce(transform.up * Speed);
        }
        else
        {
            ammunition.rigidbody2D.AddForce(Vector3.Normalize(Direction) * Speed);
        }
        ammunition.transform.parent = GameObject.Find("Ammunition").transform;
        reloadTimeRemaining = RateOfFire;
    }
}
