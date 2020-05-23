using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int playerScore;

    public UnityEvent GameOver;

    //public float timeCheck;

    //private float timeSinceLastHit;
    
    //add future player stats like total dodged bullets, dodge streak etc

    void Start()
    {
        if(playerScore == 0)
        {
            Debug.LogError("Player score is zero at the start of the game, defaulting to a score of 10");
            playerScore = 10;
        }

        scoreText.text = "Score: " + playerScore.ToString();
    }

    void Update()
    {
        //timeSinceLastHit += Time.deltaTime;

        //if(timeSinceLastHit )
    }

    //a bullet has hit the player
    public void BulletHit()
    {
        //timeSinceLastHit = 0f;
        playerScore -= 1;
        scoreText.text = "Score: " + playerScore.ToString();
        EvaluateScore();
    }

    //a bullet has been collected behind player meaning it missed, possible reward therefore for player
    public void BulletMissed()
    {
        playerScore += 1;
        scoreText.text = "Score: " + playerScore.ToString();
        EvaluateScore();
    }

    private void EvaluateScore()
    {
        if(playerScore <= 0)
        {
            scoreText.text = "Game over";
            GameOver.Invoke();
        }

        //do other evaluations in future like dodge streaks etc to trigger encouragements etc
    }
}
