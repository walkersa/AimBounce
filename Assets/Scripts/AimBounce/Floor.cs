using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ball"))
        {
            Destroy(col.gameObject);
        }
    }
}
