using UnityEngine;

public class PaddleController : MonoBehaviour
{
    #region Inspector

    public Rigidbody2D body;
    public float speed = 2.0f;

    #endregion


    #region Private Fields

    private float _currentMovementDirection;
    private Vector3 _initialPosition;

    #endregion


    private void Awake()
    {
        _initialPosition = body.transform.position;
        body.simulated = false;
    }

    // Update is called once per frame
    private void Update()
    {
        _currentMovementDirection = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _currentMovementDirection = -1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _currentMovementDirection = 1.0f;
        }
    }

    private void FixedUpdate()
    {
        if (!body.simulated)
            return;

        body.AddForce(new Vector2(speed * _currentMovementDirection, 0.0f));
    }

    public void ResetPaddle()
    {
        body.transform.position = _initialPosition;
        body.Sleep();
        body.simulated = false;
    }
}