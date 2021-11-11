using UnityEngine;

public class BasicBrickController : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    private float scaleSpeed = 1.5f;

    #endregion

    #region Private Fields

    private float _currentScaleModifier;
    private Vector3 _scaleBeforeAnimation;
    private bool _created;
    private float _waitTime;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        var transform1 = transform;
        _scaleBeforeAnimation = transform1.localScale;
        transform1.localScale = Vector3.zero;
    }

    private void Start()
    {
        GameManager.BrickCounter++;
    }

    public void BeginBrickCreation(float waitTime)
    {
        _waitTime = waitTime;
        _created = true;
    }

    private void Update()
    {
        // todo: refactor created and wait time.
        if (!_created || !(_currentScaleModifier < 1))
            return;

        if (_waitTime >= 0)
        {
            _waitTime -= Time.deltaTime;
            return;
        }

        _currentScaleModifier += Time.deltaTime * scaleSpeed;
        _currentScaleModifier = _currentScaleModifier > 1 ? 1 : _currentScaleModifier;
        transform.localScale = _scaleBeforeAnimation * _currentScaleModifier;
    }

    #endregion

    #region Methods

    public virtual void UseBrickStrategy(BallController ball)
    {
        gameObject.SetActive(false);
        GameManager.BrickCounter--;
    }

    #endregion
}