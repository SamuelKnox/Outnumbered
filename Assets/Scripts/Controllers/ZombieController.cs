using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Pathfinder))]
[RequireComponent(typeof(Attacker))]
public class ZombieController : MonoBehaviour
{
    private Pathfinder pathfinder;
    private Attacker attacker;

    void Start()
    {
        pathfinder = GetComponent<Pathfinder>();
        attacker = GetComponent<Attacker>();
    }

    void Update()
    {
        if (pathfinder.Target == null || pathfinder.IsPathBlocked() || attacker.Target == null)
        {
            FindNewTarget();
        }
        if(Vector2.Distance(attacker.Target.transform.position, transform.position) <= attacker.Range){
            attacker.AttackTarget();
        }
    }

    private void FindNewTarget()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            return;
        }
        //float targetDistance = pathfindingSystem.GetRemainingDistanceToTarget();
        //foreach (Transform ghostTransform in GameObject.FindGameObjectWithTag("Ghosts").transform)
        //{
        //    GameObject ghost = ghostTransform.gameObject;
        //    if(ghost.gameObject.)
        //}
        //{
        //    Health ghost = ghostGameObject.GetComponent<Health>();
        //    if (!ghost.IsAlive)
        //    {
        //        continue;
        //    }
        //    Agent.SetDestination(ghost.transform.position);
        //    float ghostDistance = Agent.remainingDistance;
        //    if (ghostDistance < targetDistance)
        //    {
        //        target = ghost;
        //        targetDistance = ghostDistance;
        //    }
        //}
        //Agent.SetDestination(target.transform.position);
        if (pathfinder.IsPathBlocked())
        {
            float targetDistance = Mathf.Infinity;
            foreach (GameObject structure in GameObject.FindGameObjectsWithTag("Structure"))
            {
                if (Vector2.Distance(structure.transform.position, transform.position) > attacker.Range)
                {
                    continue;
                }
                pathfinder.Agent.SetDestination(structure.transform.position);
                float structureDistance = pathfinder.Agent.remainingDistance;
                if (structureDistance < targetDistance)
                {
                    target = structure;
                    targetDistance = structureDistance;
                }
            }
            PolyNavObstacle polyNavObstacle = target.gameObject.GetComponent<PolyNavObstacle>();
            if (polyNavObstacle != null)
            {
                polyNavObstacle.enabled = false;
            }
        }
        pathfinder.Target = target;
        attacker.Target = target;
    }
}
