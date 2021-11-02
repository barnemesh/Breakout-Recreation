using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 3.0f;
    private Vector2 _ballDirection;

    // Start is called before the first frame update
    void Start ()
    {
        if ( body == null )
            return;

        _ballDirection = Vector2.one;
        body.velocity = _ballDirection.normalized * speed;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if ( body == null )
            return;

        Vector2 contactNormal = other.contacts[0].normal;
        _ballDirection = Vector2.Reflect(_ballDirection, contactNormal);
        body.velocity = _ballDirection.normalized * speed;
    }
}