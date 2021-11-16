using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region UnityEvents

    [Header("Events")]
    [SerializeField]
    private UnityEvent resetPositions;

    [SerializeField]
    private UnityEvent beginMovement;

    [SerializeField]
    private UnityEvent endGame;

    [SerializeField]
    private UnityEvent loseOneLife;

    #endregion


    #region Private Static

    private static GameManager _shared;

    #endregion


    #region Private Fields

    private int _brickCounter;
    private int _lives;
    private bool _gameOngoing = true;
    private bool _ballMoving;

    #endregion


    #region Properties

    public static int BrickCounter
    {
        get => _shared._brickCounter;
        set => _shared._brickCounter = value;
    }

    public static int Lives
    {
        get => _shared._lives;
        set => _shared._lives = value;
    }

    #endregion


    #region Public Static Functions

    public static void LoseOneLife ()
    {
        //_shared.lives.RemoveSingleLife();
        _shared.loseOneLife.Invoke();
        _shared.resetPositions.Invoke();
        _shared._ballMoving = false;
        if ( _shared._lives != 0 )
        {
            return;
        }

        print("Game Over");
        _shared.endGame.Invoke();
        _shared._gameOngoing = false;
    }

    #endregion


    #region MonoBehaviour

    private void Awake ()
    {
        _shared = this;
    }

    // Start is called before the first frame update
    void Start ()
    {
        resetPositions.Invoke();
        _ballMoving = false;
    }

    // Update is called once per frame
    private void Update ()
    {
        if ( !_gameOngoing )
            return;

        if ( _brickCounter == 0 )
        {
            print("WIN!");
            endGame.Invoke();
            _gameOngoing = false;
            return;
        }

        if ( !_ballMoving && Input.GetKeyDown(KeyCode.Space) )
        {
            beginMovement.Invoke();
            _ballMoving = true;
        }

        if ( _ballMoving && Input.GetKeyDown(KeyCode.R) )
        {
            LoseOneLife();
        }
    }

    #endregion
}