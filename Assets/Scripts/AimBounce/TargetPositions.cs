using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositions : MonoBehaviour
{
    public Transform[] targetPos;

    public GameObject targetPrefab;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        MoveTarget();
    }

    public void MoveTarget()
    {
        if (counter <= targetPos.Length)
        {
            targetPrefab.transform.position = targetPos[counter].position;
            counter += 1;
        }
        else
        {
            Debug.Log("finished");
        }

    }
}
