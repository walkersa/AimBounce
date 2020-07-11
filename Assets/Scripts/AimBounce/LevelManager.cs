using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoopTracker))]
[RequireComponent(typeof(PadTracker))]
[RequireComponent(typeof(TargetPositions))]
public class LevelManager : MonoBehaviour
{
    public List<LevelTools> levelTools = new List<LevelTools>();

    private LoopTracker loopTracker;
    private PadTracker padTracker;
    private TargetPositions targetPositions;

    private int currentLevelIndex = 0;

    public OnNewLevelStarted OnNewLevel;

    private void OnEnable()
    {
        FindRelevantComponents();
        StartFirstLevel();
    }

    private void FindRelevantComponents()
    {
        loopTracker = GetComponent<LoopTracker>();
        padTracker = GetComponent<PadTracker>();
        targetPositions = GetComponent<TargetPositions>();
    }

    private void StartFirstLevel()
    {
        levelTools[currentLevelIndex].Init();
        OnNewLevel.Invoke(levelTools[currentLevelIndex]);
    }

    public void StartNewLevel()
    {
        WrapUpPreviousLevel();
        currentLevelIndex++;
        levelTools[currentLevelIndex].Init();
        OnNewLevel.Invoke(levelTools[currentLevelIndex]);
        Debug.Log("new level initialized");
    }

    private void WrapUpPreviousLevel()
    {
        loopTracker.RemoveAllLoops();
        padTracker.RemoveAllPads();
        targetPositions.MoveTarget();
    }
}
