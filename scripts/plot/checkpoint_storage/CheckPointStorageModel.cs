using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GraphGame;

public class CheckPointStorageModel
{
    private static CheckPointStorageModel instance = new();
    private List<CheckPointNodeModel> checkPointNodeModels;
    private List<Vector2> _checkPointCoords;

    private CheckPointStorageModel() { }

    public event Action<List<CheckPointNodeModel>, List<Vector2>> AddCheckPointWithLabel;
    public event Action<Vector2, bool> CheckPointChangeVisibility;

    public void Init(List<Vector2> checkPointCoords)
    {
        checkPointNodeModels = [];
        _checkPointCoords = checkPointCoords;
        for (int i = 0; i < _checkPointCoords.Count; i++)
        {
            CheckPointNodeModel model = new();
            checkPointNodeModels.Add(model);
        }
        AddCheckPointWithLabel?.Invoke(checkPointNodeModels, checkPointCoords);
    }

    public void ChangeCheckPointVisibility(Vector2 position, bool isVisible)
    {
        CheckPointChangeVisibility?.Invoke(position, isVisible);
    }

    public void CheckCoordsCoincidence(List<Vector2> queue)
    {
        queue = queue.Select(c => c.Round()).ToList();
        bool contains = true;
        for (int i = 0; i < _checkPointCoords.Count && contains; i++)
        {
            if (!queue.Contains(_checkPointCoords[i]))
            {
                contains = false;
            }
        }
        GraphContainerModel.Instance.LevelEnded(contains);
    }

    public static CheckPointStorageModel Instance { get => instance; }
}