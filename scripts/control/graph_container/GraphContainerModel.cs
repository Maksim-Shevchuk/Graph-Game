using Godot;
using GraphGame;
using System;

public partial class GraphContainerModel
{
	private static GraphContainerModel instance;
	private Game levelLoader = Game.Instance;
	private int _interval;
	private int _margin;
	private Vector2 leftUpperCorner;
	private Rect2 graphContainerRect;

	public event Action<bool> ShowLevelEndMenu;

	public void Init(int interval, int margin)
	{
		leftUpperCorner = CoordsUtils.ToWorldCoords(new(510, 935));
		_interval = interval;
		_margin = margin;
		float rectLength = Mathf.Round(900 / (float)_interval);
		graphContainerRect = new(leftUpperCorner, new(rectLength, rectLength));
	}

	public bool HasPoint(Vector2 point)
	{
		return graphContainerRect.HasPoint(point);
	}

	public void LevelEnded(bool isWin)
	{
		ShowLevelEndMenu?.Invoke(isWin);
	}

	public void RestartGame()
	{
		levelLoader.RestartLevel();
		// Game.Instance.Init("scripts/level/json/level2.json");
	}

	public void LoadNextLevel()
	{
		levelLoader.NextLevel();
	}

	private GraphContainerModel() { }

	public static GraphContainerModel Instance { get => instance ??= new(); }
}
