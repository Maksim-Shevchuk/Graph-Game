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
    private List<Dictionary<string, float>> _obstacleDictCoords;
    private bool _extraInputEnabled;

    public LevelInfoDto(int id, int interval, int margin, Dictionary<string, float> startPosition, bool extraInputEnabled)
    {
        _id = id;
        _interval = interval;
        _margin = margin;
        _startPosition = startPosition;
        _extraInputEnabled = extraInputEnabled;
    }

    public int Id
    {
        get => _id; 
        set => _id = Id; 
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

    public Dictionary<string, float> StartPosition
    {
        get => _startPosition;
        set => _startPosition = value;
    }

    public List<Dictionary<string, float>> CheckpointDictCoords
    {
        get => _checkpointDictCoords; 
        set => _checkpointDictCoords = value; 
    }

    public List<Dictionary<string, float>> ObstacleDictCoords
    {
        get => _obstacleDictCoords;
        set => _obstacleDictCoords = value;
    }

    public bool ExtraInputEnabled 
    {
        get => _extraInputEnabled;
        set => _extraInputEnabled = value;
    }
}