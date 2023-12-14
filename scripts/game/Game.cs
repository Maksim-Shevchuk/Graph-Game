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
	private string levelPath => $"scripts/level/json/level{level}.json";
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
		_plotLayer.Init(levelInfo.Margin, levelInfo.Interval, levelInfo.CheckpointCoords);
		_controlLayer.Init();
		GraphContainerModel.Instance.Init(levelInfo.Interval, levelInfo.Margin);
		ShipModel.Instance.Init(levelInfo.StartPosition);
	}

	public void RestartLevel()
	{
		GetTree().ReloadCurrentScene();
	}

	public void NextLevel()
	{
		level++;
		RestartLevel();
	}

	public static Game Instance => instance;
	public int Level
	{
		get => level;
		set
		{
			level = value;
			// RestartLevel();
		}
	}
}