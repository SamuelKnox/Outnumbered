﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Mobility))]
public class Builder : MonoBehaviour
{
    [Tooltip("Range at which the entity builds")]
    public float Range = 1.0f;
    [Tooltip("Barricade which the entity can build")]
    public GameObject Barricade;
    [Tooltip("Turret which the entity can build")]
    public GameObject Turret;

    private Mobility mobility;

    // Use this for initialization
    void Start()
    {
        mobility = GetComponent<Mobility>();
    }

    public void Build(string structureName)
    {
        Vector2 buildPosition = transform.position + transform.up * Range;
        if (Physics2D.OverlapPoint(buildPosition))
        {
            return;
        }
        mobility.Moveable = false;
        GameObject structurePrefab = null;
        switch (structureName)
        {
            case "Barricade":
                structurePrefab = Barricade;
                break;
            case "Turret":
                structurePrefab = Turret;
                break;
        }
        GameObject structure = Instantiate(structurePrefab, transform.position + transform.up * Range, transform.rotation) as GameObject;
        structure.transform.parent = GameObject.Find("Structures").transform;
        StartCoroutine("EnableMovementAfterConstructionComplete");
    }

    public void DestroyStructure()
    {
        Vector2 destroyPosition = transform.position + transform.up * Range;
        Collider2D structureCollider = Physics2D.OverlapPoint(destroyPosition);
        if (structureCollider == null)
        {
            return;
        }
        mobility.Moveable = false;
        structureCollider.gameObject.AddComponent<Death>();
        StartCoroutine("EnableMovementAfterConstructionComplete");
    }

    private IEnumerator EnableMovementAfterConstructionComplete()
    {
        yield return new WaitForSeconds(1.0f);
        mobility.Moveable = true;
    }
}
