using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSpawner : ToolSpawner
{
    public OnCreateNewLoop onCreateNewLoop;

    void Start()
    {
        LocateHands();
    }

    public override void SubscribeToButtonEvent(HandPresence hand)
    {
        hand.PrimaryButtonPressed += SpawnTool;
    }

    public override void UnSubscribeToButtonEvent(HandPresence hand)
    {
        hand.PrimaryButtonPressed -= SpawnTool;
    }

    public override void SpawnTool()
    {
        if (levelBudget.TrackLoopBudget())
        {
            tool = Instantiate(levelBudget.SpawnLoop());
            tool.transform.position = hand.transform.position;
            onCreateNewLoop.Invoke(tool.transform);
        }
    }

    private void OnDisable()
    {
        UnSubscribeToButtonEvent(hand);
    }


}
