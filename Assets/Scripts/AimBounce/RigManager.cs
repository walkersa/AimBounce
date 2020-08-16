using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Moves the player XR Rig to the next level start position
/// </summary>
public class RigManager : MonoBehaviour
{
    public Transform[] playerStartPositions;
    public GameObject fadePanel;
    public float fadeTime;

    private Transform playerRig;
    private int counter = 0;
    

    
    void Start()
    {
        playerRig = GetComponent<Transform>();

        if(playerStartPositions.Length == 0)
        {
            Debug.LogError("no valid player rig start positions loaded");
        }

        MovePlayerToStartPosition();
    }

    //called by event on Level Manager
    public void MovePlayerToStartPosition()
    {
        FadeOut();
        MovePlayer();
        FadeIn();
        counter++;
    }

    private void MovePlayer()
    {
        playerRig.position = playerStartPositions[counter].position;
    }

    private void FadeIn()
    {
        fadePanel.SetActive(true);
        Image fader = fadePanel.GetComponentInChildren<Image>();
        fader.CrossFadeAlpha(1, fadeTime, true);
    }

    private void FadeOut()
    {
        
        Image fader = fadePanel.GetComponentInChildren<Image>();
        fader.CrossFadeAlpha(0, fadeTime, true);
        fadePanel.SetActive(false);
    }
}
