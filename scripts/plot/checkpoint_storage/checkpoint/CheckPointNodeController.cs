using Godot;

namespace GraphGame;

public partial class CheckPointNodeController
{
    private CheckPointNodeModel _model;


    public CheckPointNodeController(CheckPointNodeModel model)
    {
        _model = model;
    }

    public void MouseEntered(Vector2 position)
    {
        _model.ShowTooltip(position);
    }

    public void MouseExited(Vector2 position)
    {
        _model.HideTooltip(position);
    }

}