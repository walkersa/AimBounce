using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float velocity;

    private Rigidbody rb;

    
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        MoveBall();
    }

    private void MoveBall()
    {
        rb.AddForceAtPosition(transform.forward * velocity, transform.position, ForceMode.Impulse);
    }

    public void BoostBall(float boostVel)
    {
        Debug.Log("boost ball velocity");
        rb.velocity *= boostVel;
    }

}
