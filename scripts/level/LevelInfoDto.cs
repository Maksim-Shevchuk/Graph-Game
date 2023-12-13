using Godot;
using System;
using System.Collections.Generic;

[Serializable]
public class LevelInfoDto
{
    private int _id;
    private int _interval;
    private int _margin;
    private Dictionary<string, float> _startPosition;
    private List<Dictionary<string, float>> _checkpointDictCoords;

    public LevelInfoDto(int id, int interval, int margin, Dictionary<string, float> startPosition)
    {
        _id = id;
        _interval = interval;
        _margin = margin;
        _startPosition = startPosition;
    }

    public int Id
    {
        get { return _id; }
        set { _id = Id; }
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

    public Dictionary<string, float> StartPosition
    {
        get => _startPosition;
        set => _startPosition = value;
    }

    public List<Dictionary<string, float>> CheckpointDictCoords
    {
        get { return _checkpointDictCoords; }
        set { _checkpointDictCoords = value; }
    }
}