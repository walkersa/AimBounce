using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FindBestAttachPoint : MonoBehaviour
{
    public Transform[] attachPoints;

    //look into this
    public XROffsetGrabbable grabInteractable;

    //public XRGrabInteractable grabInteractable;

    public void FindAttachPoint(XRBaseInteractor interactor)
    {
        Vector3 currentHandPos = interactor.transform.position;
        float distance = 0.5f;

        for (int i = 0; i < attachPoints.Length; i++)
        {
            if(Vector3.Distance(currentHandPos, attachPoints[i].position) < distance)
            {
                distance = Vector3.Distance(currentHandPos, attachPoints[i].position);
                grabInteractable.attachTransform = attachPoints[i];
            }
        }
    }
}
