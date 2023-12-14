using Godot;
using System.Collections.Generic;
using System.Linq;

namespace GraphGame;

public partial class Ship : CharacterBody2D
{
	private static Ship instance;
	private ShipModel model = ShipModel.Instance;
	private ShipController controller = ShipController.Instance;
	public const float Speed = 5f;
	private Queue<Vector2> path = [];
	private Vector2 target;
	private float targetAngle;
	private Vector2 fromPos;
	private float timelerped = 1;

	private Ship() { }

	public override void _Ready()
	{
		instance = this;
		model.ModelUpdated += UpdateView;
		model.PathBuilt += SetPath;
		SetPhysicsProcess(false);
	}

	public override void _ExitTree()
	{
		model.ModelUpdated -= UpdateView;
		model.PathBuilt -= SetPath;
	}

	public void UpdateView(Vector2 vector)
	{
		Position = CoordsUtils.ToScreenCoords(vector);
		target = Position;
	}

	private void SetPath(Queue<Vector2> path)
	{
		this.path = path;
		SetPhysicsProcess(true);
	}

	public override void _PhysicsProcess(double delta)
	{
		timelerped += (float)delta * Speed;
		if (timelerped < 1)
		{
			Rotation = Mathf.LerpAngle(targetAngle, Position.DirectionTo(target).Angle() + Mathf.Pi / 2.0f, timelerped);
			Position = fromPos.Lerp(target, timelerped);
		}
		else if (!TryGetNextPosition())
		{
			Position = target;
		}
	}

	private bool TryGetNextPosition()
	{
		if (path.TryDequeue(out target))
		{
			target = CoordsUtils.ToScreenCoords(target);
			targetAngle = Rotation;
			fromPos = Position;
			timelerped = 0;
			return true;
		}
		else if (!path.Any())
		{
			controller.ShipFinsishedMoving();
		}
		return false;
	}

	public static Ship Instance { get => instance; }
}