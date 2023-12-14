using Godot;
using GraphGame;
using System;

public partial class GraphContainerModel
{
	private static GraphContainerModel instance;
	private Game levelLoader;
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
		levelLoader  = Game.Instance;
	}

	public bool HasPoint(Vector2 point)
	{
		return graphContainerRect.HasPoint(point);
	}

	public void LevelEnded(bool isWin)
	{
		ShowLevelEndMenu?.Invoke(isWin);
	}

	public void RestartLevel()
	{
		levelLoader.RestartLevel();
	}

	public void LoadNextLevel()
	{
		levelLoader.NextLevel();
	}

	private GraphContainerModel() { }

	public static GraphContainerModel Instance { get => instance ??= new(); }
}
