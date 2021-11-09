using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFactory : MonoBehaviour
{
    [SerializeField]
    public GameObject basicBlock = default;

    [SerializeField]
    public GameObject hardBlock = default;

    [SerializeField]
    public GameObject middleBlock = default;

    public GameObject CreateBlock (string type, Vector2 position)
    {
        GameObject brick = null;
        switch (type)
        {
            case "basic":
                brick = GameObject.Instantiate(basicBlock, position, Quaternion.identity);
                break;
            case "hard":
                brick = GameObject.Instantiate(hardBlock, position, Quaternion.identity);
                break;
            case "middle":
                brick = GameObject.Instantiate(middleBlock, position, Quaternion.identity);
                break;
            default:
                return null;
        }

        brick.tag = "Block";
        return brick;
    }
}