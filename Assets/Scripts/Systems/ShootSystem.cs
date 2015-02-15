using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShooterComponent))]
public class ShootSystem : MonoBehaviour
{
    private ShooterComponent shooterComponent;
    private float reloadTimeRemaining;

    void Start()
    {
        shooterComponent = GetComponent<ShooterComponent>();
        reloadTimeRemaining = shooterComponent.RateOfFire;
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
        Vector3 ammunitionPosition = transform.position + new Vector3(transform.up.x * shooterComponent.SpawnOffset.x, transform.up.y * shooterComponent.SpawnOffset.y);
        GameObject ammunition = Instantiate(ammunitionPrefab, ammunitionPosition, transform.rotation) as GameObject;
        if (shooterComponent.Direction == Vector2.zero)
        {
            ammunition.rigidbody2D.AddForce(transform.up * shooterComponent.Speed);
        }
        else
        {
            ammunition.rigidbody2D.AddForce(Vector3.Normalize(shooterComponent.Direction) * shooterComponent.Speed);
        }
        ammunition.transform.parent = GameObject.Find("Ammunition").transform;
        reloadTimeRemaining = shooterComponent.RateOfFire;
    }
}
