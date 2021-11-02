using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWin : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color initialColor = Color.red;
    public Color winColor = Color.green;

    private bool _gameWon;

    private void Start ()
    {
        if ( spriteRenderer == null )
            return;

        spriteRenderer.color = initialColor;
    }

    // Update is called once per frame
    void Update ()
    {
        if ( _gameWon || spriteRenderer == null || transform.childCount != 0 )
            return;

        _gameWon = true;
        spriteRenderer.color = winColor;
    }
}