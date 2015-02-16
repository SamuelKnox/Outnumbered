using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    void Start()
    {
        switch (tag)
        {
            case "Player":
                GetComponent<Mobility>().Moveable = false;
                GetComponent<Animator>().SetTrigger("Die");
                Destroy(gameObject, 3.0f);
                break;
            case "Ghost":
                gameObject.SetActive(false);
                GameObject zombie = Instantiate(Resources.Load("Zombie 3"), transform.position, transform.rotation) as GameObject;
                zombie.transform.parent = GameObject.Find("Enemies").transform;
                GameManager.Instance.GhostLives--;
                break;
            case "Structure":
                GetComponent<Animator>().SetTrigger("Destroying");
                Destroy(gameObject, 1.0f);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
        }
    }
}
