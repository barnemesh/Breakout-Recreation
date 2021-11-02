using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHitController : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        if ( other.gameObject.CompareTag("Ball") )
        {
            Destroy(gameObject);
        }
    }
}