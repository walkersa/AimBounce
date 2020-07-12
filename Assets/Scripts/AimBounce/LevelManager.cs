using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoopTracker))]
[RequireComponent(typeof(PadTracker))]
[RequireComponent(typeof(TargetPositions))]
[RequireComponent(typeof(Scorer))]
public class LevelManager : MonoBehaviour
{
    public List<LevelTools> levelTools = new List<LevelTools>();

    private LoopTracker loopTracker;
    private PadTracker padTracker;
    private TargetPositions targetPositions;
    private Scorer scorer;

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
        scorer = GetComponent<Scorer>();
    }

    private void StartFirstLevel()
    {
        levelTools[currentLevelIndex].Init();
        scorer.BeginLevel(levelTools[currentLevelIndex]);
        OnNewLevel.Invoke(levelTools[currentLevelIndex]);
    }

    public void StartNewLevel()
    {
        WrapUpPreviousLevel();
        currentLevelIndex++;
        levelTools[currentLevelIndex].Init();
        scorer.BeginLevel(levelTools[currentLevelIndex]);
        OnNewLevel.Invoke(levelTools[currentLevelIndex]);
        Debug.Log("new level initialized");
    }

    private void WrapUpPreviousLevel()
    {
        scorer.LevelComplete();
        loopTracker.RemoveAllLoops();
        padTracker.RemoveAllPads();
        targetPositions.MoveTarget();
    }
}
