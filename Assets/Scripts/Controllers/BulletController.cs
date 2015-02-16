using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Enemy":
                collider.gameObject.AddComponent<Death>();
                Destroy(gameObject);
                break;
            case "Trees":
                Destroy(gameObject);
                break;
        }
    }
}
