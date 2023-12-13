using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphGame;

public partial class CheckPointStorage : Node2D
{
	[Export] private PackedScene packedScene;
	private static CheckPointStorage instance;
	private CheckPointStorageModel model = CheckPointStorageModel.Instance;
	private CheckPointStorageController controller = CheckPointStorageController.Instance;
	private List<CheckPointNode> checkPointsViews;

	private CheckPointStorage() { }

	public override void _Ready()
	{
		checkPointsViews = [];
		model.AddCheckPointWithLabel += AddCheckPoints;
		model.CheckPointChangeVisibility += CheckPointVisibilityChanged;
	}

	private void AddCheckPoints(List<CheckPointNodeModel> checkPointsModels, List<Vector2> checkPointCoords)
	{
		for (int i = 0; i < checkPointsModels.Count; i++)
		{
			CheckPointNodeController nodeController = new(checkPointsModels[i]);
			CheckPointNode view = packedScene.Instantiate<CheckPointNode>();
			view.Model = checkPointsModels[i];
			view.Controller = nodeController;
			view.Position = CoordsUtils.ToScreenCoords(checkPointCoords[i]);
			view.AttachTooltip(checkPointCoords[i]);
			checkPointsViews.Add(view);
			AddChild(view);
			AddChild(view.Tooltip);
		}
	}

	private void CheckPointVisibilityChanged(Vector2 position, bool isVisible)
	{
		Label tooltip = checkPointsViews.Find(cp => cp.Position == position).Tooltip;
		tooltip.Visible = isVisible;
	}

	public static CheckPointStorage Instance { get => instance ??= new(); }
}
