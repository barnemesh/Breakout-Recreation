using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject heart;
    public int initialLives = 3;

    private int _currentLivesCount = 0;
    private GameObject[] _hearts;

    private void Start ()
    {
        _hearts = new GameObject[initialLives];
        _currentLivesCount = initialLives;
        for ( int i = 0; i < initialLives; i++ )
        {
            Transform myTransform = transform;
            _hearts[i] = Instantiate(heart,
                myTransform.position + (myTransform.right * i),
                myTransform.rotation,
                myTransform);

            _hearts[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && _currentLivesCount > 0 )
        {
            _currentLivesCount--;
            _hearts[_currentLivesCount].SetActive(false);
        }
    }
}