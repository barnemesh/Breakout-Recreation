using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class HardBrickController : BasicBrickController
{
    [SerializeField]
    private SpriteRenderer myRenderer = default;

    public Sprite brokenSprite = default;

    private bool _notHit = true;

    public override void UseBrickStrategy (BallController ball)
    {
        if ( _notHit )
        {
            _notHit = false;
            myRenderer.sprite = brokenSprite;
            return;
        }

        base.UseBrickStrategy(ball);
    }
}