using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeParentControl : MonoBehaviour
{
    [SerializeField]
    private LifeAnimatorScript child;

    public void DisableLife ()
    {
        child.DisableAnimation();
    }
}