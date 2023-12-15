using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphGame;

[Serializable]
public partial class LevelInfo
{
    private int _id;
    private int _interval;
    private int _margin;
    private Vector2 _startPosition;
    private List<Vector2> _checkpointCoords;
    private List<Vector2> _obstacleCoords;
    private bool _extraInputEnabled;

    public LevelInfo(int id, int interval, int margin, Vector2 startPosition, bool extraInputEnabled)
    {
        _id = id;
        _interval = interval;
        _margin = margin;
        _startPosition = startPosition;
        _extraInputEnabled = extraInputEnabled;
    }

    public LevelInfo(int id, int interval, int margin, Vector2 startPosition,
        List<Vector2> checkpointCoords, List<Vector2> obstacleCoords, bool extraInputEnabled)
    {
        _id = id;
        _interval = interval;
        _margin = margin;
        _startPosition = startPosition;
        _checkpointCoords = checkpointCoords;
        _obstacleCoords = obstacleCoords;
        _extraInputEnabled = extraInputEnabled;
    }

    public int Id
    {
        get => _id;
    }

    public int Interval
    {
        get => _interval;
        set => _interval = value;
    }

    public int Margin
    {
        get => _margin;
        set => _margin = value;
    }

    public Vector2 StartPosition
    {
        get => _startPosition;
        set => _startPosition = value;
    }

    public List<Vector2> CheckpointCoords
    {
        get => _checkpointCoords;
        set => _checkpointCoords = value;
    }

    public List<Vector2> ObstacleCoords
    {
        get => _obstacleCoords;
        set => _obstacleCoords = value;
    }

    public bool ExtraInputEnabled
    {
        get => _extraInputEnabled;
        set => _extraInputEnabled = value;
    }
}