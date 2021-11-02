using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PaddleMovementController : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 2.0f;
    private float _currentMovementDirection;

    // Update is called once per frame
    void Update ()
    {
        _currentMovementDirection = 0.0f;
        if ( Input.GetKey(KeyCode.LeftArrow) )
        {
            _currentMovementDirection = -1.0f;
        }

        if ( Input.GetKey(KeyCode.RightArrow) )
        {
            _currentMovementDirection = 1.0f;
        }
    }

    private void FixedUpdate ()
    {
        if ( body == null )
            return;

        body.AddForce(new Vector2(speed * _currentMovementDirection, 0.0f));
    }
}