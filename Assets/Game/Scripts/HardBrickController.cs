using UnityEngine;

public class HardBrickController : BasicBrickController
{
    [SerializeField]
    private SpriteRenderer myRenderer;

    public Sprite brokenSprite;

    private bool _notHit = true;

    public override void UseBrickStrategy(BallController ball)
    {
        if (_notHit)
        {
            _notHit = false;
            myRenderer.sprite = brokenSprite;
            return;
        }

        base.UseBrickStrategy(ball);
    }
}