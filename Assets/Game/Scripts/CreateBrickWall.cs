using UnityEngine;

[RequireComponent(typeof(BrickFactory))]
public class CreateBrickWall : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    private Vector2 centerOfFirstBlock;

    [SerializeField]
    private int numberOfRows = 5;

    [SerializeField]
    private int numberOfColumns = 11;

    #endregion

    #region Private Fields

    private int _index;
    private BrickFactory _factory;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        _factory = GetComponent<BrickFactory>();
    }

    private void Start()
    {
        Vector2 offset = Vector2.zero;
        for (int row = 0; row < numberOfRows; row++)
        {
            string blockType = row switch
            {
                var x when x == 1 || x == 0 => "hard",
                2 => "middle",
                _ => "basic"
            };

            for (int col = 0; col < numberOfColumns; col++)
            {
                offset.Set(col * 1.5f, -0.5f * row);
                GameObject currentBlock = _factory.CreateBlock(blockType, centerOfFirstBlock + offset);
                currentBlock.transform.parent = transform;
                currentBlock.name = $"Block ({row},{col})";
                BasicBrickController currentBrickController = currentBlock.GetComponent<BasicBrickController>();
                currentBrickController.BeginBrickCreation((row + col) * 0.2f);
            }
        }
    }

    #endregion
}