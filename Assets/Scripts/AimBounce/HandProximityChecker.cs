using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandProximityChecker : MonoBehaviour
{
    public PadHandles handles;

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            handles.Reveal();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            handles.Hide();
        }
    }

}
