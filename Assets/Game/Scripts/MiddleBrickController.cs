using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBrickController : BasicBrickController
{
    public override void UseBrickStrategy (BallController ball)
    {
        base.UseBrickStrategy(ball);
        ball.SetMaxSpeed();
    }
}