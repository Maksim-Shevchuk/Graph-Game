using Godot;
using GraphGame;
using System;

public partial class Obstacle : Area2D
{
	[Export] private AnimatedSprite2D asteroid;
	private ObstacleModel _model;
	private ObstacleController _controller;
	private Label _tooltip;

	public void AttachTooltipTooltip(Vector2 position)
	{
		position = CoordsUtils.ToScreenCoords(position);
		Vector2 relativeCoords = CoordsUtils.ToWorldCoords(position);
		Label label = new()
		{
			Visible = false,
			Position = new(position.X + 15, position.Y + 10),
			Text = $"({relativeCoords.X}; {relativeCoords.Y})"
		};
		label.Modulate = Colors.Black;
		_tooltip = label;
	}

	public void OnMouseEntered()
	{
		_controller.ShowTooltip(Position);
	}

	public void OnMouseExited()
	{
		_controller.HideTooltip(Position);
	}

	private void OnBodyEntered(Node2D body)
	{
		if (ShipModel.Instance.JustContainsInPath(CoordsUtils.ToWorldCoords(Position)))
		{
			asteroid.Play("explode");
			_controller.BodyInteractedWithObstacle(CoordsUtils.ToWorldCoords(Position));
		}
	}

	public ObstacleModel Model
	{
		get => _model;
		set => _model = value;
	}

	public ObstacleController Controller
	{
		get => _controller;
		set => _controller = value;
	}

	public Label Tooltip
	{
		get => _tooltip;
		set => _tooltip = value;
	}
}
