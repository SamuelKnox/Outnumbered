using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BuilderComponent))]
[RequireComponent(typeof(MobilityComponent))]
public class BuildSystem : MonoBehaviour
{
    private BuilderComponent builderComponent;
    private MobilityComponent mobilityComponent;

    // Use this for initialization
    void Start()
    {
        builderComponent = GetComponent<BuilderComponent>();
        mobilityComponent = GetComponent<MobilityComponent>();
    }

    public void Build(GameObject structurePrefab)
    {
        Vector2 buildPosition = transform.position + transform.up * builderComponent.Range;
        if (Physics2D.OverlapPoint(buildPosition))
        {
            return;
        }
        mobilityComponent.Moveable = false;
        GameObject structure = Instantiate(structurePrefab, transform.position + transform.up * builderComponent.Range, transform.rotation) as GameObject;
        StartCoroutine("EnableMovementAfterBuildingComplete");
    }

    private IEnumerator EnableMovementAfterBuildingComplete()
    {
        yield return new WaitForSeconds(1.0f);
        mobilityComponent.Moveable = true;
    }
}
