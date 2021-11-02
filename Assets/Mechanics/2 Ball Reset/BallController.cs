using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D body;
    // private Rigidbody2D _body;

    private Vector3 _initialPosition;

    private void Start ()
    {
        // _body = GetComponent<Rigidbody2D>();
        if ( body == null )
            return;

        body.Sleep();
        _initialPosition = body.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        // key down to avoid too fast changes.
        if ( body == null || !Input.GetKeyDown(KeyCode.Space) )
            return;

        if ( body.IsAwake() )
        {
            body.transform.position = _initialPosition;
            body.Sleep();
        }
        else
        {
            body.WakeUp();
        }
    }
}