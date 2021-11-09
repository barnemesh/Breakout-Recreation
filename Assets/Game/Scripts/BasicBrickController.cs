using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBrickController : MonoBehaviour
{
    public float scaleSpeed = 0.2f;
    public SpriteRenderer mySpriteRenderer;
    public Sprite brokenBrick;
    private float _currentScaleModifier;
    private Vector3 _scaleBeforeAnimation;
    private bool _created;
    private int _hitCounter;

    //todo: create brick strategy Factory!!
    // todo: register each brick at start!
    private void Awake ()
    {
        _scaleBeforeAnimation = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        if ( other.gameObject.CompareTag("Ball") )
        {
            if ( CompareTag("Hard Block") && _hitCounter < 1 )
            {
                _hitCounter++;
                mySpriteRenderer.sprite = brokenBrick;
                return;
            }

            Destroy(gameObject);
        }
    }

    public void BeginBrickCreation ()
    {
        _created = true;
    }

    private void Update ()
    {
        if ( !_created || !(_currentScaleModifier < 1) )
            return;

        _currentScaleModifier += (Time.deltaTime * scaleSpeed);
        _currentScaleModifier = _currentScaleModifier > 1 ? 1 : _currentScaleModifier;
        transform.localScale = _scaleBeforeAnimation * _currentScaleModifier;
    }


    #region Methods

    // yellow for example:
    public void UseBrickStrategy (BallController ball)
    {
        ball.SetMaxSpeed();
    }

    #endregion
}