using System;
using System.IO;
using Godot;
using GraphGame;

public partial class LevelMenuModel
{
    private static LevelMenuModel instance;
    public event Action<int> ModelUpdated;
    public event Action<int> RunCurrentLevel;

    private LevelMenuModel() { }

    public void Init()
    {
        int levelsCount = Directory.GetFiles(@"scripts\level\json").Length;
    }

    public void RunLevel(int level)
    {
        RunCurrentLevel?.Invoke(level);
    }

    public static LevelMenuModel Instance { get => instance ??= new(); }

}