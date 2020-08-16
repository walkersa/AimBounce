using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : ToolSpawner
{
    private bool ballActive = false;

    private float timer;

    void Start()
    {
        LocateHands();

        timer = 5f;
    }

    public override void SubscribeToButtonEvent(HandPresence hand)
    {
        hand.PrimaryButtonPressed += SpawnBall;
    }

    public override void UnSubscribeToButtonEvent(HandPresence hand)
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
                ballActive = false;
            }
        }
            
    }

    private void SpawnBall()
    {
        if (!ballActive)
        {
            Debug.Log("ball spawned");
            tool = Instantiate(toolPrefab) as GameObject;
            Ball ball = tool.GetComponent<Ball>();
            tool.transform.position = transform.position;
            Vector3 shootDir = transform.forward;
            ball.MoveBall(shootDir);
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
        UnSubscribeToButtonEvent(hand);
    }
}
