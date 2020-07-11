using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelToolsBudget", menuName = "Levels Tools")]
public class LevelTools : ScriptableObject
{
    [Header("Bounce Pads")]
    [Tooltip("the number of bounce pads the player can spawn this level")]
    public int padBudget;
    public GameObject padPrefab;
    private int padBudgetCounter;

    [Header("Loops")]
    [Tooltip("the number of boost loops the player can spawn this level")]
    public int loopBudget;
    public GameObject loopPrefab;
    private int loopBudgetCounter;

    [Header("Miscellaneous Tools")]
    [Tooltip("the number of miscellaneous tools the player can spawn this level")]
    public int miscToolBudget;
    public GameObject[] miscToolsPrefabs;
    private int miscBudgetCounter;

    public bool levelComplete = false;


    public void Init()
    {
        padBudgetCounter = 1;
        loopBudgetCounter = 1;
        miscBudgetCounter = 1;
    }

    public GameObject SpawnPad()
    {
        return padPrefab;
    }

    public GameObject SpawnLoop()
    {
        return loopPrefab;
    }

    public GameObject SpawnMiscTool(int index)
    {
        return miscToolsPrefabs[index];
    }

    public bool TrackPadBudget()
    {
        if(padBudgetCounter <= padBudget)
        {
            padBudgetCounter++;
            return true;
        }
        else
        {
            Debug.Log("pad budget for this level is maxed out");
            return false;
        }
    }

    public bool TrackLoopBudget()
    {
        if (loopBudgetCounter <= loopBudget)
        {
            loopBudgetCounter++;
            return true;
        }
        else
        {
            Debug.Log("loop budget for this level is maxed out");
            return false;
        }
    }

    public bool TrackMiscBudget()
    {
        if (miscBudgetCounter <= miscToolBudget)
        {
            miscBudgetCounter++;
            return true;
        }
        else
        {
            Debug.Log("misc tool budget for this level is maxed out");
            return false;
        }
    }
    
}
