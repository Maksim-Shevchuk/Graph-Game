using System;
using Godot;

namespace GraphGame;

public partial class PlayAreaController
{
    private static PlayAreaController instance = new();
    private PlayAreaModel model = PlayAreaModel.Instance;

    private PlayAreaController() { }

    public void HandleRunButtonPressed(string mathExpression, float xZero, float delta)
    {
        model.HandleMathExpression(mathExpression, xZero , delta);
    }


    public static PlayAreaController Instance { get => instance ??= new(); }

    public PlayAreaModel Model { get => model; set => model = value; }
}