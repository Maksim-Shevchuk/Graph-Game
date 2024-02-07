using Godot;
using GraphGame;

public partial class ObstacleModel
{
    private CheckPointStorageModel _storageModel = CheckPointStorageModel.Instance;
    private ShipModel shipModel;

    public void ChangeTooltipVisibility(Vector2 position, bool isVisible)
    {
        _storageModel.ChangeObstacleVisibility(position, isVisible);
    }

    public void BodyInteractedWithObstacle(Vector2 position)
    {
        shipModel = ShipModel.Instance;
        if (shipModel.ContainsInPath(position))
        {
            GraphContainerModel.Instance.LevelEnded(false);
        }
    }

    public void BodyInteractedWithObstacle()
    {
        GraphContainerModel.Instance.LevelEnded(false);
    }
}