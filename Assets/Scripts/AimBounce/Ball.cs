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
    }

    public void MoveBall(Vector3 shootDirection)
    {
        rb.AddForceAtPosition(shootDirection * velocity, transform.position, ForceMode.Impulse);
    }

    public void BoostBall(float boostVel)
    {
        Debug.Log("boost ball velocity");
        rb.velocity *= boostVel;
    }

}
