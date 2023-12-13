using System;
using Godot;
using org.mariuszgromada.math.mxparser;

namespace GraphGame;

public partial class Game : Node2D
{
	private static Game instance;

	[Export] private Ship _ship;

	[Export] private PlotLayer _plotLayer;

	[Export] private ControlLayer _controlLayer;
	private static int level = 2;
	private string levelPath = string.Format("scripts/level/json/level{0}.json", level);
	public override void _Ready()
	{
		License.iConfirmNonCommercialUse("GraphGame");
		Init();
	}

	public void Init()
	{
		LevelInfo levelInfo = JsonSerializerUtils.DeserializeLevelInfo(levelPath);
		CoordsUtils.Init(levelInfo.Margin, levelInfo.Interval);
		_plotLayer.Init(levelInfo.Margin, levelInfo.Interval, levelInfo.CheckpointCoords);
		_controlLayer.Init();
		GraphContainerModel.Instance.Init(levelInfo.Interval, levelInfo.Margin);
		ShipModel.Instance.Init(levelInfo.StartPosition);
	}

	public void RestartLevel()
	{
		GD.Print(level);
		GetTree().ReloadCurrentScene();
	}

	public void NextLevel()
	{
		level++;
		GD.Print(level);
		GetTree().ReloadCurrentScene();
	}

	private Game() { }

	public static Game Instance { get => instance ??= new(); }
	public static int Level
	{
		get => level;
		set => level = value;
	}
}