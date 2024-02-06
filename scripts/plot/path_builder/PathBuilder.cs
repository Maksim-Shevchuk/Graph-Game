using Godot;
using System.Collections.Generic;

public partial class PathBuilder : Node2D
{
	private static PathBuilder _instance;
	private PathBuilderModel model = PathBuilderModel.Instance;
	private Queue<Vector2> _path = [];
	private readonly Vector2 pointToAdd = new(0.01f, 0.01f);

	public override void _Ready()
	{
		_instance = this;
		model.PathBuilt += SetPath;
		QueueRedraw();
	}

	public override void _ExitTree()
	{
		model.PathBuilt -= SetPath;
	}

	public override void _Draw()
	{
		Vector2 leftUpperCorner = new(450, 35);
		float rectLength = 985;
		var expandedRect = new Rect2(leftUpperCorner, new Vector2(rectLength + 55, rectLength));
		DrawPath();
	}

	public void SetPath(Queue<Vector2> path)
	{
		_path = new Queue<Vector2>();
		_path = path;
		QueueRedraw();
	}

	private void DrawPath()
	{
		foreach (var item in _path)
		{
			DrawCircle(item, 2, Colors.White);
		}
	}

	public void Init()
	{
		model.Init();
	}

	public static PathBuilder Instance
	{
		get => _instance;
	}
}
