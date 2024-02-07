using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GraphGame;

public class CheckPointStorageModel
{
    private static CheckPointStorageModel instance;
    private List<CheckPointNodeModel> checkPointNodeModels;
    private List<ObstacleModel> obstacleModels;
    private List<Vector2> _checkPointCoords;
    private List<Vector2> _obstacleCoords;
    private CheckPointStorageModel() { }

    public event Action<List<CheckPointNodeModel>, List<Vector2>> AddCheckPointWithLabel;
    public event Action<List<ObstacleModel>, List<Vector2>> AddObstacleWithLabel;
    public event Action<Vector2, bool> CheckPointChangeVisibility;
    public event Action<Vector2, bool> ObstacleChangeVisibility;
    public event Action CheckVisibilityCheckPoints;

    public void Init(List<Vector2> checkPointCoords, List<Vector2> obstacleCoords)
    {
        checkPointNodeModels = [];
        _checkPointCoords = checkPointCoords;
        for (int i = 0; i < _checkPointCoords.Count; i++)
        {
            CheckPointNodeModel model = new();
            checkPointNodeModels.Add(model);
        }
        AddCheckPointWithLabel?.Invoke(checkPointNodeModels, checkPointCoords);
        obstacleModels = [];
        _obstacleCoords = obstacleCoords;
        for (int i = 0; i < _obstacleCoords.Count; i++)
        {
            ObstacleModel model = new();
            obstacleModels.Add(model);
        }
        AddObstacleWithLabel?.Invoke(obstacleModels, obstacleCoords);
    }

    public void ChangeCheckPointVisibility(Vector2 position, bool isVisible)
    {
        CheckPointChangeVisibility?.Invoke(position, isVisible);
    }

    public void ChangeObstacleVisibility(Vector2 position, bool isVisible)
    {
        ObstacleChangeVisibility?.Invoke(position, isVisible);
    }

    public void CheckCoordsCoincidence(List<Vector2> queue)
    {
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

    public void IsAllCheckPointsInvisible()
    {
        CheckVisibilityCheckPoints?.Invoke();
    }

    public void IsLevelWon(bool isNoNodeVisible)
    {
        GraphContainerModel.Instance.LevelEnded(isNoNodeVisible);
    }

    public static CheckPointStorageModel Instance { get => instance ??= new(); }
}