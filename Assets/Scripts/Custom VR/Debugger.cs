using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugger : MonoBehaviour
{
    private TextMeshProUGUI text;

    public HandPresence[] hands; 

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        Invoke("GetHands", 1f);
    }

    private void GetHands()
    {
        hands = FindObjectsOfType<HandPresence>();
        foreach(var hand in hands)
        {

            if (hand.controllerCharacteristics == UnityEngine.XR.InputDeviceCharacteristics.Left)
            {
                //hand.SendDebugMessage += LogLeftHandMessage;
            }

            if (hand.controllerCharacteristics == UnityEngine.XR.InputDeviceCharacteristics.Right)
            {
                //hand.SendDebugMessage += LogRightHandMessage;
            }
        }
    }

    public void LogLeftHandMessage(HandPresence hand)
    {
        //string logMessage = hand.debugger + " on left hand";
        //text.text = logMessage;
    }

    public void LogRightHandMessage(HandPresence hand)
    {
        //string logMessage = hand.debugger + " on right hand";
        //text.text = logMessage;
    }





}
