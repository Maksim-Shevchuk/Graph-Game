using Godot;

namespace GraphGame;

public partial class ControlSceneModel
{
    private static ControlSceneModel instance;

    private ControlSceneModel() { }

    public static ControlSceneModel Instance { get => instance??= new();}
}