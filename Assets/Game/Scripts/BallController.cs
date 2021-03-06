using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    #region Inspector

    public Rigidbody2D body;
    public float speed = 1.0f;

    [Header("Self Components")]
    [SerializeField]
    private ParticleSystem myParticle;

    [SerializeField]
    private AudioSource myAudio;

    #endregion


    #region Private Fields

    private Vector2 _ballDirection;

    private Vector3 _initialPosition;

    private int _paddleHitCounter;
    private float _speedModifier = 1.0f;
    private BallController _myScript;
    private bool _emissionEnabled;

    #endregion


    #region MonoBehaviour

    // Start is called before the first frame update
    private void Awake()
    {
        _myScript = GetComponent<BallController>();
        _initialPosition = body.transform.position;
        body.Sleep();
    }

    private void Start()
    {
        myParticle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            GameManager.LoseOneLife();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        myAudio.Play();
        if (other.gameObject.CompareTag("Block"))
        {
            other.gameObject.GetComponent<BasicBrickController>().UseBrickStrategy(_myScript);
        }

        Vector2 v = Vector2.zero;
        if (other.gameObject.CompareTag("Paddle"))
        {
            float ballX = transform.position.x;
            float paddleX = other.transform.position.x;
            float distanceFromCenterX = ballX - paddleX;
            float percentageOfDistance = distanceFromCenterX / (other.transform.localScale.x / 2);
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

        if (_speedModifier >= 4.0f && myParticle.isStopped)
        {
            myParticle.Play();
        }

        Vector2 contactNormal = other.GetContact(0).normal;
        _ballDirection = Vector2.Reflect(_ballDirection, contactNormal);
        _ballDirection = (_ballDirection + v).normalized;
        body.velocity = _ballDirection * speed * _speedModifier;
    }

    #endregion


    #region Methods

    public void BeginBallMovement()
    {
        body.WakeUp();
        _ballDirection = Random.onUnitSphere;
        _ballDirection.Normalize();
        body.velocity = _ballDirection * speed * _speedModifier;
        if (_speedModifier >= 4.0f && myParticle.isStopped)
        {
            myParticle.Play();
        }
    }

    public void ResetBall()
    {
        body.transform.position = _initialPosition;
        body.Sleep();
        myParticle.Stop();
    }

    public void EndGame()
    {
        gameObject.SetActive(false);
    }

    public void SetMaxSpeed()
    {
        _speedModifier = 4.0f;
        _paddleHitCounter = 12;
    }

    #endregion
}