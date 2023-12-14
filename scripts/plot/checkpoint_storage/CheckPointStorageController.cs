using Godot;

namespace GraphGame;

public partial class CheckPointStorageController : Resource
{
    private static CheckPointStorageController instance = new();
    private CheckPointStorageModel model = CheckPointStorageModel.Instance;

    private CheckPointStorageController() { }

    public static CheckPointStorageController Instance { get => instance ?? new(); }
}