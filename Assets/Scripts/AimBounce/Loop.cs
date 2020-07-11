using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private bool complete;
    public float velocityMultiplier;

    public bool m_complete
    {
        get
        {
            return complete;
        }
        set
        {
            complete = value;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ball"))
        {
            
            GameObject currentBall = col.gameObject;
            IncreaseVelocity(currentBall);
            m_complete = true;
            Debug.Log("loop completed");
        }
    }

    private void IncreaseVelocity(GameObject go)
    {
        Ball activeBall = go.GetComponent<Ball>();
        if(activeBall == null)
        {
            Debug.LogError("Ball gameobject does not contain Ball component");
            return;
        }
        else
        {
            Debug.Log("increase velocity");
            activeBall.BoostBall(velocityMultiplier);
        }
    }
}
