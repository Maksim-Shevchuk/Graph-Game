using Godot;
using System.Collections.Generic;

namespace GraphGame;

public partial class CheckPointStorage : Node2D
{
	[Export] private PackedScene checkPointPackedScene;
	[Export] private PackedScene obstaclePackedScene;

	private static CheckPointStorage instance;
	private CheckPointStorageModel model = CheckPointStorageModel.Instance;
	private CheckPointStorageController controller = CheckPointStorageController.Instance;
	private List<CheckPointNode> checkPointsViews;
	private List<Obstacle> obstacleViews;

	private CheckPointStorage() { }

	public override void _Ready()
	{
		foreach (Node node in GetChildren())
		{
			node.QueueFree();
		}
		instance = this;
		checkPointsViews = [];
		obstacleViews = [];
		model.AddCheckPointWithLabel += AddCheckPoints;
		model.AddObstacleWithLabel += AddObstacles;
		model.CheckPointChangeVisibility += CheckPointVisibilityChanged;
		model.ObstacleChangeVisibility += ObstacleVisibilityChanged;
	}

	public override void _ExitTree()
	{
		model.AddCheckPointWithLabel -= AddCheckPoints;
		model.AddObstacleWithLabel -= AddObstacles;
		model.CheckPointChangeVisibility -= CheckPointVisibilityChanged;
		model.ObstacleChangeVisibility -= ObstacleVisibilityChanged;
	}

	private void AddCheckPoints(List<CheckPointNodeModel> checkPointsModels, List<Vector2> checkPointCoords)
	{
		for (int i = 0; i < checkPointsModels.Count; i++)
		{
			CheckPointNodeController nodeController = new(checkPointsModels[i]);
			CheckPointNode view = checkPointPackedScene.Instantiate<CheckPointNode>();
			view.Model = checkPointsModels[i];
			view.Controller = nodeController;
			view.Position = CoordsUtils.ToScreenCoords(checkPointCoords[i]);
			view.AttachTooltip(checkPointCoords[i]);
			checkPointsViews.Add(view);
			AddChild(view);
			AddChild(view.Tooltip);
		}
	}

	public void AddObstacles(List<ObstacleModel> obstacleModels, List<Vector2> obstacleCoords)
	{
		for (int i = 0; i < obstacleCoords.Count; i++)
		{
			ObstacleController obstacleController = new(obstacleModels[i]);
			Obstacle view = obstaclePackedScene.Instantiate<Obstacle>();
			view.Model = obstacleModels[i];
			view.Controller = obstacleController;
			view.Position = CoordsUtils.ToScreenCoords(obstacleCoords[i]);
			view.AttachTooltipTooltip(obstacleCoords[i]);
			obstacleViews.Add(view);
			AddChild(view);
			AddChild(view.Tooltip);
		}
	}

	private void CheckPointVisibilityChanged(Vector2 position, bool isVisible)
	{
		Label tooltip = checkPointsViews.Find(cp => cp.Position == position).Tooltip;
		tooltip.Visible = isVisible;
	}

	private void ObstacleVisibilityChanged(Vector2 position, bool isVisible)
	{
		Label tooltip = obstacleViews.Find(cp => cp.Position == position).Tooltip;
		tooltip.Visible = isVisible;
	}

	public static CheckPointStorage Instance { get => instance; }
}
