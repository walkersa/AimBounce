using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    public int pointMultiplier;

    public TextMeshProUGUI scoreText;

    private float levelTimer = 0f;

    private float score = 0;

    private int toolsUsed;
    private int levelToolBudget;

    private bool levelActive = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (levelActive)
            levelTimer += Time.deltaTime;
    }

    public void BeginLevel(LevelTools LevelTools)
    {
        levelToolBudget = (LevelTools.padBudget + LevelTools.loopBudget + LevelTools.miscToolBudget);
        toolsUsed = levelToolBudget;
        levelActive = true;
    }

    public void LevelComplete()
    {
        levelActive = false;
        CalculateScore();
        levelTimer = 0f;
    }

    public void ToolUsed()
    {
        if (toolsUsed > 1)
        {
            toolsUsed--;
        }
        else
        {
            Debug.Log("all tools used, should not be calling this method once tool budget reached");
        }
    }

    public void ToolDiscarded()
    {
        //if player no longer needs a tool it can be discarded and registed for score purposes
    }

    private void CalculateScore()
    {
        Debug.Log("time to complete level = " + levelTimer);
        score = ((pointMultiplier * toolsUsed) / (levelTimer / 30f));
        string displayScore = String.Format("{0:0}", score);
        scoreText.text = displayScore;
        Debug.Log($"Score for level = {displayScore}");
    }
}
