using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;

    private GameObject newBall;

    private bool ballActive = false;

    public HandPresence[] hands;

    private HandPresence rightHand;

    private float timer;

    void Start()
    {
        hands = FindObjectsOfType<HandPresence>();
        if(hands.Length == 0)
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

        timer = 5f;
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
        hand.PrimaryButtonPressed += SpawnBall;
    }

    private void UnSubscribeToButtonEvent(HandPresence hand)
    {
        hand.PrimaryButtonPressed -= SpawnBall;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }

        if (ballActive)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                Destroy(newBall);
                ballActive = false;
            }
        }
            
    }

    private void SpawnBall()
    {
        if (!ballActive)
        {
            newBall = Instantiate(ball) as GameObject;
            newBall.transform.position = transform.position;
            timer = 5f;
            ballActive = true;
            
        }
    }

    public void TargetHit()
    {
        ballActive = false;
    }

    private void OnDisable()
    {
        UnSubscribeToButtonEvent(rightHand);
    }
}
