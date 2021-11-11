public class MiddleBrickController : BasicBrickController
{
    public override void UseBrickStrategy (BallController ball)
    {
        base.UseBrickStrategy(ball);
        ball.SetMaxSpeed();
    }
}