using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        ResetLevel();
        LoadPlayer();
        LoadGhosts();
        RemoveDeathScripts();
        Destroy(this);
    }

    private void ResetLevel()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy.gameObject);
        }
        foreach (GameObject structure in GameObject.FindGameObjectsWithTag("Structure"))
        {
            Destroy(structure.gameObject);
        }
        foreach (GameObject enemySpawner in GameObject.FindGameObjectsWithTag("Enemy Spawner"))
        {
            enemySpawner.GetComponent<EnemySpawner>().ResetSpawner();
        }
    }

    private void LoadPlayer()
    {
        GameObject player = Instantiate(Resources.Load("Player"), Vector3.zero, Quaternion.identity) as GameObject;
        Camera.main.GetComponent<TargetFollower>().Target = player.transform;
    }

    private void LoadGhosts()
    {
        foreach (Transform ghost in GameObject.Find("Ghosts").transform)
        {
            ghost.gameObject.GetComponent<Turret>().enabled = false;
            ghost.gameObject.SetActive(true);
            ghost.transform.position = Vector3.zero;
        }
    }

    private void RemoveDeathScripts()
    {
        foreach (Death deathScript in GameObject.FindObjectsOfType<Death>())
        {
            Destroy(deathScript);
        }
    }
}
