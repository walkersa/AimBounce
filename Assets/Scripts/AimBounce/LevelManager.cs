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

    public List<LevelSetup> levelSetups = new List<LevelSetup>();

    public Transform rig;
    public Transform turret;
    public Transform target;

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

    //used for in editor testing only. Can be removed for headset version
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartNewLevel();
        }
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
        levelSetups[currentLevelIndex].Init();
        scorer.BeginLevel(levelTools[currentLevelIndex]);
        OnNewLevel.Invoke(levelTools[currentLevelIndex]);
    }

    public void StartNewLevel()
    {
        WrapUpPreviousLevel();
        currentLevelIndex++;
        SpinUpNewLevel();
        Debug.Log("new level initialized");
    }

    private void WrapUpPreviousLevel()
    {
        scorer.LevelComplete();
        loopTracker.RemoveAllLoops();
        padTracker.RemoveAllPads();
        targetPositions.MoveTarget();
    }

    private void SpinUpNewLevel()
    {
        levelSetups[currentLevelIndex].Init();
        levelSetups[currentLevelIndex].Setup(rig, turret, target);

        levelTools[currentLevelIndex].Init();

        scorer.BeginLevel(levelTools[currentLevelIndex]);
        OnNewLevel.Invoke(levelTools[currentLevelIndex]);
    }
}
