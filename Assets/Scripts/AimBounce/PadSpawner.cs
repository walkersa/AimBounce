using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSpawner : MonoBehaviour
{
    public GameObject padPrefab;

    private GameObject newPad;

    public HandPresence[] hands;

    private HandPresence rightHand;

    public OnCreateNewPad onCreateNewPad;

    // Start is called before the first frame update
    void Start()
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
                if (item.controllerCharacteristics == UnityEngine.XR.InputDeviceCharacteristics.Right)
                {
                    rightHand = item;
                    SubscribeToButtonEvent(item);
                    Debug.Log("subscribed");
                }
            }
        }
    }

    private void TryLocateHandsAgain()
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
                Debug.Log("looking for right hand");
                if (item.controllerCharacteristics == UnityEngine.XR.InputDeviceCharacteristics.Right)
                {
                    rightHand = item;
                    SubscribeToButtonEvent(item);
                    Debug.Log("subscribed");
                }
            }
        }
    }

    private void SubscribeToButtonEvent(HandPresence hand)
    {
        hand.SecondaryButtonPressed += SpawnPad;
    }

    private void UnSubscribeToButtonEvent(HandPresence hand)
    {
        hand.SecondaryButtonPressed -= SpawnPad;
    }

    private void SpawnPad()
    {
        newPad = Instantiate(padPrefab);
        newPad.transform.position = rightHand.transform.position;
        onCreateNewPad.Invoke(newPad.transform);
    }

    private void OnDisable()
    {
        UnSubscribeToButtonEvent(rightHand);
    }
}
