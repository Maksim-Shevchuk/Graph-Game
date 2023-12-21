using System;
using System.IO;
using System.Linq;
using Godot;

public partial class LevelMenuModel
{
    private static LevelMenuModel instance;
    public event Action<int> ModelUpdated;

    private LevelMenuModel() { }

    public void Init()
    {
        int levelsCount = Directory.GetFiles(@"scripts\level\json").Length;
        ModelUpdated?.Invoke(levelsCount);
    }

    public static LevelMenuModel Instance { get => instance ??= new(); }

}