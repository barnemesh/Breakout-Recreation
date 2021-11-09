using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUIController : MonoBehaviour
{
    #region Inspector

    public GameObject life;

    [SerializeField]
    private int numberOfLives = 3;

    #endregion


    #region Private Fields

    private GameObject[] _livesList;

    #endregion


    // Start is called before the first frame update
    void Start ()
    {
        GameManager.Lives = numberOfLives;

        _livesList = new GameObject[numberOfLives];
        for ( int i = 0; i < numberOfLives; i++ )
        {
            Transform myTransform = transform;
            _livesList[i] = Instantiate(life,
                myTransform.position - (myTransform.up * i) * 0.5f,
                myTransform.rotation,
                myTransform);

            _livesList[i].SetActive(true);
        }
    }

    public void RemoveSingleLife ()
    {
        numberOfLives--;
        GameManager.Lives--;
        // todo: animation.
        Destroy(_livesList[numberOfLives]);
    }
}