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

    public LevelInfo(int id, int interval, int margin, Vector2 startPosition)
    {
        _id = id;
        _interval = interval;
        _margin = margin;
        _startPosition = startPosition;

    }

    public LevelInfo(int id, int interval, int margin, Vector2 startPosition, List<Vector2> checkpointCoords)
    {
        _id = id;
        _interval = interval;
        _margin = margin;
        _startPosition = startPosition;
        _checkpointCoords = checkpointCoords;
        // UpdateCoordFields();
    }

    public void  UpdateCoordFields()
    {
        _startPosition = CoordsUtils.ToScreenCoords(_startPosition);
        _checkpointCoords = _checkpointCoords.Select(c => CoordsUtils.ToScreenCoords(c)).ToList();
    }

    public int Id
    {
        get { return _id; }
    }

    public int Interval
    {
        get { return _interval; }
        set { _interval = value; }
    }

    public int Margin
    {
        get { return _margin; }
        set { _margin = value; }
    }

    public Vector2 StartPosition
    {
        get => _startPosition;
        set => _startPosition = value;
    }

    public List<Vector2> CheckpointCoords
    {
        get { return _checkpointCoords; }
        set { _checkpointCoords = value; }
    }
}