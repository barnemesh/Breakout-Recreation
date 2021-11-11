using UnityEngine;

public class BrickFactory : MonoBehaviour
{
    [SerializeField]
    public GameObject basicBlock;

    [SerializeField]
    public GameObject hardBlock;

    [SerializeField]
    public GameObject middleBlock;

    public GameObject CreateBlock(string type, Vector2 position)
    {
        GameObject brick;
        switch (type)
        {
            case "basic":
                brick = Instantiate(basicBlock, position, Quaternion.identity);
                break;
            case "hard":
                brick = Instantiate(hardBlock, position, Quaternion.identity);
                break;
            case "middle":
                brick = Instantiate(middleBlock, position, Quaternion.identity);
                break;
            default:
                return null;
        }

        brick.tag = "Block";
        return brick;
    }
}