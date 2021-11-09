using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBrickController : MonoBehaviour
{
    public float scaleSpeed = 1.5f;

    private float _currentScaleModifier;
    private Vector3 _scaleBeforeAnimation;
    private bool _created;

    //todo: create brick strategy Factory!!
    // todo: register each brick at start!
    void Awake ()
    {
        _scaleBeforeAnimation = transform.localScale;
        transform.localScale = Vector3.zero;
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
    public virtual void UseBrickStrategy (BallController ball)
    {
        Destroy(gameObject);
    }

    #endregion
}