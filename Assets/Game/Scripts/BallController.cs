using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    #region Inspector

    public Rigidbody2D body;
    public float speed = 1.0f;

    #endregion


    #region Private Fields

    private Vector2 _ballDirection;

    private Vector3 _initialPosition;

    // todo: modifier to enum?
    private int _paddleHitCounter;
    private float _speedModifier = 1.0f;
    private BallController _myScript;

    #endregion


    #region MonoBehaviour

    // Start is called before the first frame update
    void Awake ()
    {
        // todo: add error print?
        if ( body == null )
            return;

        _myScript = GetComponent<BallController>();
        _initialPosition = body.transform.position;
        body.Sleep();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if ( other.gameObject.CompareTag("Floor") )
        {
            GameManager.LoseOneLife();
        }
    }


    private void OnCollisionEnter2D (Collision2D other)
    {
        if ( body == null )
            return;

        if ( other.gameObject.CompareTag("Block") )
        {
            other.gameObject.GetComponent<BasicBrickController>().UseBrickStrategy(_myScript);
        }

        Vector2 v = Vector2.zero;
        if ( other.gameObject.CompareTag("Paddle") )
        {
            float distanceFromCenterX = transform.position.x - other.transform.position.x;
            float percentageOfDistance = distanceFromCenterX / (transform.localScale.x / 2);
            v.Set(percentageOfDistance, 1);
            _paddleHitCounter++;
            _speedModifier = _paddleHitCounter switch
            {
                4 => 2.0f,
                8 => 3.0f,
                var n when n >= 12 => 4.0f,
                _ => _speedModifier
            };
        }

        // todo: without normalizing _ballDirection?
        Vector2 contactNormal = other.GetContact(0).normal;
        _ballDirection = Vector2.Reflect(_ballDirection, contactNormal);
        _ballDirection += v; // todo: normalize here? keep the direction
        // todo: or keep _ball direction same as velocity?
        body.velocity = _ballDirection.normalized * speed * _speedModifier;
    }

    #endregion


    #region Methods

    public void BeginBallMovement ()
    {
        body.WakeUp();
        _ballDirection = Random.onUnitSphere; //todo: .normalized?
        body.velocity = _ballDirection.normalized * speed * _speedModifier;
    }

    public void ResetBall ()
    {
        body.transform.position = _initialPosition;
        body.Sleep();
    }

    public void EndGame ()
    {
        Destroy(gameObject);
    }

    public void SetMaxSpeed ()
    {
        _speedModifier = 4.0f;
        _paddleHitCounter = 12; // todo: max as constant
    }

    #endregion
}