using System.IO;
using Godot;
using org.mariuszgromada.math.mxparser;

namespace GraphGame;

public partial class Game : Node2D
{
	private static Game instance;

	[Export] private Ship _ship;

	[Export] private PlotLayer _plotLayer;

	[Export] private ControlLayer _controlLayer;
	private static int level = 3;
	private string levelPath => $"scripts/level/json/level{level}.json";
	private int levelAmount => Directory.GetFiles(@"scripts\level\json").Length;

	public override void _Ready()
	{
		instance = this;
		License.iConfirmNonCommercialUse("GraphGame");
		Init();
	}

	private void Init()
	{
		LevelInfo levelInfo = JsonSerializerUtils.DeserializeLevelInfo(levelPath);
		CoordsUtils.Init(levelInfo.Margin, levelInfo.Interval);
		_plotLayer.Init(levelInfo.Margin, levelInfo.Interval, levelInfo.CheckpointCoords, levelInfo.ObstacleCoords);
		_controlLayer.Init(levelInfo.ExtraInputEnabled);
		GraphContainerModel.Instance.Init(levelInfo.Interval);
		ShipModel.Instance.Init(levelInfo.StartPosition);
	}

	public void RestartLevel()
	{
		GetTree().ReloadCurrentScene();
	}

	public bool NextLevel()
	{
		//todo
		if (level != levelAmount)
		{
			level++;
			RestartLevel();
			return true;
		}
		return false;
	}

	public static Game Instance => instance;
	public int Level
	{
		get => level;
		set
		{
			level = value;
		}
	}
}