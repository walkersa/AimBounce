using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PadHandles : MonoBehaviour
{
    public float tweenTime;

    private Vector3 maxScale;

    void Start()
    {
        maxScale = transform.localScale;
        Hide();
    }

    public void Reveal()
    {
        Tween.LocalScale(transform, maxScale, tweenTime, 0.2f,Tween.EaseBounce);
    }

    public void Hide()
    {
        Tween.LocalScale(transform, Vector3.zero, tweenTime, 0.2f, Tween.EaseLinear);
    }
}
