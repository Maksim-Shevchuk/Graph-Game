using System;
using Godot;

namespace GraphGame;

public partial class CheckPointNode : Area2D
{
	[Export] private AnimatedSprite2D animatedSprite;
	private CheckPointNodeModel _model;
	private CheckPointNodeController _controller;
	private Label _tooltip;

	public CheckPointNode() { }

	public override void _Ready()
	{
		animatedSprite.Play("idle");
	}

	public void AttachTooltip(Vector2 position)
	{
		position = CoordsUtils.ToScreenCoords(position);
		Vector2 relativeCoords = CoordsUtils.ToWorldCoords(position);
		Label label = new()
		{
			Visible = false,
			Position = new(position.X + 15, position.Y + 15),
			Text = $"({relativeCoords.X}; {relativeCoords.Y})"
		};
		label.Modulate = Colors.Black;
		_tooltip = label;
	}

	public void OnMouseEntered()
	{
		_controller.MouseEntered(Position);
	}

	public void OnMouseExited()
	{
		_controller.MouseExited(Position);
	}

	private void OnBodyEntered(Node2D body)
	{
		if (ShipModel.Instance.JustContainsInPath(CoordsUtils.ToWorldCoords(Position)))
		{
			Visible = false;
		}
	}

	public CheckPointNodeModel Model
	{
		get => _model;
		set => _model = value;
	}

	public CheckPointNodeController Controller
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