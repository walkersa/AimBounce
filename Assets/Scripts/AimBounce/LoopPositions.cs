using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPositions : MonoBehaviour
{
    public GameObject[] loopGroups;

    private int counter = 0;

    void Start()
    {
        SetUpLoops();
    }

    public void SetUpLoops()
    {
        if(counter <= loopGroups.Length)
        {
            if(counter == 0)
            {
                loopGroups[counter].SetActive(true);
                RegisterLoops();
                counter++;
            }
            else
            {
                loopGroups[counter - 1].SetActive(false);
                loopGroups[counter].SetActive(true);
                RegisterLoops();
                counter++;
            }
        }
        else
        {
            Debug.Log("no more loop prefabs");
        }
    }

    private void RegisterLoops()
    {
        LoopManager manager = GetComponent<LoopManager>();
        manager.ClearLoops();

        Loop[] loops = loopGroups[counter].GetComponentsInChildren<Loop>();
        foreach (var item in loops)
        {
            manager.AddLoop(item);
        }

    }
}
