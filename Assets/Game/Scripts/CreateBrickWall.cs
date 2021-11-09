using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBrickWall : MonoBehaviour
{
    private int _index;
    

    // todo: create the bricks - not only activate.
    private void FixedUpdate ()
    {
        if ( _index < transform.childCount )
        {
            BasicBrickController currentBrickController =
                transform.GetChild(_index).GetComponent<BasicBrickController>();

            currentBrickController.BeginBrickCreation();
            _index++;
        }
    }
}