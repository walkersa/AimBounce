using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public float force;
    public Vector3 trajectory;

    private Rigidbody rb;

    public void AssignSettings(float forceSetting, Vector3 trajectorySetting)
    {
        force = forceSetting;
        trajectory = trajectorySetting;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        rb.AddForce(trajectory * force);
    }
}
