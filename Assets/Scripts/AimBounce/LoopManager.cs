using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    public List<Loop> loopList = new List<Loop>();

    private bool loopsComplete;

    public void AddLoop(Loop item)
    {
        loopList.Add(item);
    }

    public void ClearLoops()
    {
        loopList.Clear();
    }

    public bool VerifyCompletion()
    {
        Debug.Log("verifying completion");
        foreach (var item in loopList)
        {
            if (item.m_complete)
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
