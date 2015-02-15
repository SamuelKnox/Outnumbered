using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    [Tooltip("Distance from entity where the ammunition spawns")]
    public float SpawnDistance;
    [Tooltip("Speed at which the ammunition leaves the shooter")]
    public float Speed = 1.0f;
    [Tooltip("Direction in which the ammunition will travel.  If Vector2.zero, the ammunition will travel in the direction that the entity is facing.")]
    public Vector2 Direction = Vector2.zero;
    [Tooltip("Rate in seconds at which the entity is able to fire")]
    public float RateOfFire = 1.0f; private float reloadTimeRemaining;
    [Tooltip("Ammunition which will be shot by this entity")]
    public GameObject Ammunition;

    void Start()
    {
        reloadTimeRemaining = RateOfFire;
    }

    void Update()
    {
        reloadTimeRemaining -= Time.deltaTime;
    }

    public bool Shoot()
    {
        if (reloadTimeRemaining > 0)
        {
            return false;
        }
        Vector2 ammunitionPosition = transform.position + transform.up * SpawnDistance;
        GameObject ammunition = Instantiate(Ammunition, ammunitionPosition, transform.rotation) as GameObject;
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
        return true;
    }
}
