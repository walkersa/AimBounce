using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSpawner : ToolSpawner
{
    public OnCreateNewPad onCreateNewPad;

    // Start is called before the first frame update
    void Start()
    {
        LocateHands();
    }

    public override void SubscribeToButtonEvent(HandPresence hand)
    {
        hand.SecondaryButtonPressed += SpawnTool;
    }

    public override void UnSubscribeToButtonEvent(HandPresence hand)
    {
        hand.SecondaryButtonPressed -= SpawnTool;
    }

    public override void SpawnTool()
    {
        if (levelBudget.TrackPadBudget())
        {
            tool = Instantiate(levelBudget.SpawnPad());
            tool.transform.position = hand.transform.position;
            onCreateNewPad.Invoke(tool.transform);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("spawn pad");
            SpawnTool();
        }
    }

    private void OnDisable()
    {
        UnSubscribeToButtonEvent(hand);
    }
}
