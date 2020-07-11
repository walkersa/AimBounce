using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToolSpawner : MonoBehaviour
{
    public InputDeviceCharacteristics InputDeviceCharacteristics;

    public GameObject toolPrefab;

    public HandPresence[] hands;

    public LevelTools levelBudget;

    [HideInInspector]
    public GameObject tool;

    [HideInInspector]
    public HandPresence hand;

    public virtual void LocateHands()
    {
        hands = FindObjectsOfType<HandPresence>();
        if (hands.Length == 0)
        {
            Invoke("TryLocateHandsAgain", 1f);
        }
        else
        {
            foreach (var item in hands)
            {
                if (item.controllerCharacteristics == InputDeviceCharacteristics)
                {
                    hand = item;
                    SubscribeToButtonEvent(item);
                    Debug.Log("subscribed");
                }
            }
        }
    }

    public virtual void TryLocateHandsAgain()
    {
        hands = FindObjectsOfType<HandPresence>();
        if (hands.Length == 0)
        {
            Debug.LogError("no hand presence objects found");
        }
        else
        {
            foreach (var item in hands)
            {
                Debug.Log($"looking for {InputDeviceCharacteristics} hand");
                if (item.controllerCharacteristics == InputDeviceCharacteristics)
                {
                    hand = item;
                    SubscribeToButtonEvent(item);
                    Debug.Log("subscribed");
                }
            }
        }
    }

    public virtual void SubscribeToButtonEvent(HandPresence hand)
    {
        
    }

    public virtual void UnSubscribeToButtonEvent(HandPresence hand)
    {
        
    }

    public virtual void SpawnTool()
    {
        tool = Instantiate(toolPrefab);
        tool.transform.position = hand.transform.position;
    }

    public virtual void UpdateLevelTools(LevelTools newTools)
    {
        levelBudget = newTools;
    }
}
