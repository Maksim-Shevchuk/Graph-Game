using System;
using Godot;

namespace GraphGame;

public partial class PlayAreaModel
{
    private static PlayAreaModel instance = new();
    private static ShipModel shipModel = ShipModel.Instance;
    private bool _isExpandedInputVisible;
    public event Action<bool> ChangeVisibilityExpandedInput;
    private PlayAreaModel() { }


    public void Init(bool isExpandedInputVisible)
    {
        _isExpandedInputVisible = isExpandedInputVisible;
        ChangeVisibilityExpandedInput?.Invoke(_isExpandedInputVisible);
    }

    public void HandleMathExpression(string mathExp, float xZero, float delta)
    {
        MovementModel movementModel;
        movementModel = new(mathExp);
        if (!float.IsNaN(xZero))
        {
            movementModel.XBorder = MathF.Round(xZero, 2);
        }
        if (!float.IsNaN(delta))
        {
            movementModel.Increment = delta;
        }
        shipModel.MovementModel = movementModel;
    }

    public static PlayAreaModel Instance { get => instance ??= new(); }
}