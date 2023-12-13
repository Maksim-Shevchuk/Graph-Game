using System;
using Godot;

namespace GraphGame;

public partial class CheckPointNodeModel
{
    private CheckPointStorageModel _storageModel = CheckPointStorageModel.Instance;

    public CheckPointNodeModel() { }

    public void ShowTooltip(Vector2 position)
    {
        _storageModel.ChangeCheckPointVisibility(position, true);
    }

    public void HideTooltip(Vector2 position)
    {
        _storageModel.ChangeCheckPointVisibility(position, false);
    }

    public void CheckIsRemoving(Vector2 position)
    {

    }
}