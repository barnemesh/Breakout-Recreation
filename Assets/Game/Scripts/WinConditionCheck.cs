using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionCheck : MonoBehaviour
{
    public PaddleController paddleScript;
    public BallController ballScript;

    //todo: move to GameManager

    // Update is called once per frame
    void Update ()
    {
        // todo: change to counter instead of children - use register. 
        if ( GameManager.GameWon || transform.childCount != 0 )
            return;

        GameManager.GameWon = true;

        print("WIN!");
        paddleScript.ResetPaddle();
        ballScript.EndGame();
    }
}