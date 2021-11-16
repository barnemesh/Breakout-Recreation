using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAnimatorScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void DisableAnimation ()
    {
        animator.SetTrigger("Disable");
    }

    public void DisableLife ()
    {
        gameObject.SetActive(false);
    }
}