using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Inspector

    [Header("Controllers")]
    // public BallController ball;
    //
    // public PaddleController paddle;
    public LivesUIController lives;
    // public CreateBrickWall brickCreator = default;

    #endregion


    #region UnityEvents

    [Header("Events")]
    [SerializeField]
    private UnityEvent resetPositions;

    [SerializeField]
    private UnityEvent beginMovement;

    [SerializeField]
    private UnityEvent endGame;

    #endregion


    #region Private Fields

    private int _lives;
    private bool _gameOngoing = true;
    private bool _gameWon;
    private bool _ballMoving; // todo: change from ball not manager

    #endregion


    #region Properties

    public static int Lives
    {
        get => _shared._lives;
        set => _shared._lives = value;
    }

    public static bool GameWon
    {
        get => _shared._gameWon;
        set => _shared._gameWon = value;
    }

    #endregion


    private static GameManager _shared;

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
    void Update ()
    {
        if ( !_gameOngoing )
            return;

        if ( GameWon )
        {
            print("WIN!");
            resetPositions.Invoke(); // todo: reset only paddle?
            _gameOngoing = false;
            return;
        }

        if ( !_ballMoving && Input.GetKeyDown(KeyCode.Space) )
        {
            beginMovement.Invoke();
            _ballMoving = true;
        }

        // todo: press R to manually loose 1 life.
        if ( _ballMoving && Input.GetKeyDown(KeyCode.R) )
        {
            LoseOneLife();
        }
    }

    public static void LoseOneLife ()
    {
        _shared.lives.RemoveSingleLife();
        _shared.resetPositions.Invoke();
        _shared._ballMoving = false;
        if ( _shared._lives != 0 )
        {
            return;
        }

        _shared.endGame.Invoke();
        print("Game Over"); //todo: to constant message
        _shared._gameOngoing = false;
        GameWon = false;
    }
}