using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PadTracker : MonoBehaviour
{
    public List<Transform> activePads = new List<Transform>();

    void Start()
    {
        GameObject[] pads = GameObject.FindGameObjectsWithTag("Pad");
        foreach (var item in pads)
        {
            activePads.Add(item.transform);
        }
    }

    public void AddPad(Transform newPad)
    {
        Debug.Log("new pad tracked");

        if (newPad.tag == "Pad")
            activePads.Add(newPad);
    }

    public void RemovePad(Transform pad)
    {
        activePads.Remove(pad);
    }

    public void RemoveAllPads()
    {
        for (int i = activePads.Count; i-- > 0;)
        {
            Transform pad = activePads[i];
            activePads.Remove(activePads[i]);
            Destroy(pad.gameObject);
        }
    }
}
