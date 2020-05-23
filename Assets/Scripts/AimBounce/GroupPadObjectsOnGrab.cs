using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupPadObjectsOnGrab : MonoBehaviour
{

    public Transform[] padObjects;

    private Transform realParent;

    void Start()
    {
        
        realParent = padObjects[0].parent;
        Debug.Log(realParent.name);
    }

    public void ParentTransform()
    {
        for (int i = 0; i < padObjects.Length; i++)
        {
            padObjects[i].SetParent(transform);
        }
        
    }

    public void UnparentTransform()
    {
        for (int i = 0; i < padObjects.Length; i++)
        {
            padObjects[i].SetParent(realParent);
        }
        
    }
}
