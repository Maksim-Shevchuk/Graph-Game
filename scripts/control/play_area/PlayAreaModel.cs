using System;
using Godot;

namespace GraphGame;

public partial class PlayAreaModel
{
    private static PlayAreaModel instance = new();
    private ShipModel shipModel = ShipModel.Instance;
    private PathBuilderModel pathBuilderModel = PathBuilderModel.Instance;
    private bool _isExpandedInputVisible;
    public event Action<bool> ChangeVisibilityExpandedInput;
    public event Action StopPhysics;
    private PlayAreaModel() { }

    public void Init(bool isExpandedInputVisible)
    {
        _isExpandedInputVisible = isExpandedInputVisible;
        ChangeVisibilityExpandedInput?.Invoke(_isExpandedInputVisible);
    }

    public void HandleMathExpression(string mathExp, float xZero, float delta)
    {
        MovementModel movementModel = new(mathExp);
        if (!float.IsNaN(xZero))
        {
            movementModel.XBorder = xZero;
        }
        if (!float.IsNaN(delta))
        {
            movementModel.Increment = delta;
        }
        shipModel.MovementModel = movementModel;
        StopPhysics?.Invoke();
        pathBuilderModel.HidePath();
    }

    public void VisualizePath(string mathExpression, float xZero, float delta)
    {
        MovementModel movementModel = new(mathExpression);
        if (!float.IsNaN(xZero))
        {
            movementModel.XBorder = xZero;
        }
        if (!float.IsNaN(delta))
        {
            movementModel.Increment = delta;
        }
        pathBuilderModel.MovementModel = movementModel;

    }

    public static PlayAreaModel Instance { get => instance ??= new(); }
}