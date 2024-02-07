using Godot;

public partial class ObstacleController
{
    private ObstacleModel _model;

    public ObstacleController(ObstacleModel model)
    {
        _model = model;
    }

    public void ShowTooltip(Vector2 position)
    {
        _model.ChangeTooltipVisibility(position, true);
    }

    public void HideTooltip(Vector2 position)
    {
        _model.ChangeTooltipVisibility(position, false);
    }

    public void BodyInteractedWithObstacle(Vector2 position)
    {
        _model.BodyInteractedWithObstacle(position);
    } 
    public void BodyInteractedWithObstacle()
    {
        _model.BodyInteractedWithObstacle();
    }
}