using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup", menuName = "Level Setup")]
public class LevelSetup : ScriptableObject
{
    [Tooltip("where the player, turret and target should spawn in this level")]
    public GameObject levelPositionsPrefab;

    private Transform rig;
    private Transform turret;
    private Transform target;


    public void Init()
    {
        GameObject positions = Instantiate(levelPositionsPrefab);
        positions.transform.position = new Vector3(0f, 0f, 0f);

        IndentifyPositions(positions);
    }

    private void IndentifyPositions(GameObject prefab)
    {
        Transform[] tForms = prefab.GetComponentsInChildren<Transform>();

        foreach (var item in tForms)
        {
            switch (item.tag)
            {
                case "Turret":
                    turret = item;
                    break;

                case "Rig":
                    rig = item;
                    break;

                case "Target":
                    target = item;
                    break;

                default:
                    Debug.LogError("no tag on level positions prefab found");
                    break;
            }
        }
    }

    public void Setup(Transform r, Transform s, Transform t)
    {
        SetRigPosition(r);
        SetTurretPosition(s);
        SetTargetPosition(t);
    }

    public void SetRigPosition(Transform t)
    {
        t.position = rig.position;
        t.rotation = rig.rotation;
    }

    public void SetTurretPosition(Transform t)
    {
        t.position = turret.position;
        t.rotation = turret.rotation;
    }

    public void SetTargetPosition(Transform t)
    {
        t.position = target.position;
        t.rotation = target.rotation;
    }
}
