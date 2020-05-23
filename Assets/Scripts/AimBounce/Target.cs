using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent OnTargetHit;
    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("ball hit target");
        OnTargetHit.Invoke();
        Destroy(collider.gameObject);
    } 
}
