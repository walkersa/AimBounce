using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopTracker : MonoBehaviour
{
    public List<Transform> activeLoops = new List<Transform>();

    void Start()
    {
        GameObject[] pads = GameObject.FindGameObjectsWithTag("Loop");
        foreach (var item in pads)
        {
            activeLoops.Add(item.transform);
        }
    }

    public void AddLoop(Transform newLoop)
    {
        if (newLoop.tag == "Loop")
            activeLoops.Add(newLoop);
    }

    public void RemoveLoop(Transform loop)
    {
        activeLoops.Remove(loop);
    }

    public void RemoveAllLoops()
    {
        for (int i = activeLoops.Count; i-- > 0;)
        {
            Transform loop = activeLoops[i];
            activeLoops.Remove(activeLoops[i]);
            Destroy(loop.gameObject);
        }
    }
}
