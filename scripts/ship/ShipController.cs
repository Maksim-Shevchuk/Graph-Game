using System.Collections;
using System.Collections.Generic;
using Godot;

namespace GraphGame;

public partial class ShipController
{
    private static ShipController instance;
    private ShipModel model = ShipModel.Instance;

    private ShipController() { }

    public void ShipFinsishedMoving() 
    {
        model.MovementStopped();
    }

    public static ShipController Instance { get => instance ??= new(); }
}