using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAnimatorScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource myAudio;

    public void DisableAnimation()
    {
        animator.SetTrigger("Disable");
    }

    public void DisableLife()
    {
        gameObject.SetActive(false);
    }
}