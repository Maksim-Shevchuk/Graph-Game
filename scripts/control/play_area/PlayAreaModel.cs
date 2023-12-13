using System;
using Godot;

namespace GraphGame;

public partial class PlayAreaModel
{
    private static PlayAreaModel instance = new();
    private static ShipModel shipModel = ShipModel.Instance;

    private PlayAreaModel() { }


    public void Init() { }

    public void HandleMathExpression(string mathExp)
    {
        MovementModel movementModel = new(mathExp);
        shipModel.MovementModel = movementModel;
    }

    public static PlayAreaModel Instance { get => instance ??= new(); }
}