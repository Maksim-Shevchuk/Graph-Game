using System;
using System.Security.Cryptography;
using Godot;

namespace GraphGame;

public partial class Axises : Node2D
{
	private static Axises instance;
	// private AxisesModel model = AxisesModel.Instance;
	private static int margin ;
	private static int interval;
	private static readonly Vector2 boundPosition = new(510, 935);
	private static int containerSideLength = 900 - 10;
	private static Vector2 startPosition;
	private static Vector2 toY { get; set; }
	private static Vector2 toX { get; set; }
	private Color color = Colors.Yellow;
	private float width = 2f;

	private Axises() { }
	public override void _Draw()
	{
		DrawArrow(startPosition, toY);
		DrawArrow(startPosition, toX);
		DrawScaleLines(interval);
		// DrawArrow(model.StartPosition, model.ToY);
		// DrawArrow(model.StartPosition, model.ToX);
		// DrawScaleLines(model.Interval);
	}

	// public Axises(AxisesModel model) { this.model = model; }

	public void Init(int Margin, int Interval)
	{
		margin = Margin;
		interval = Interval;
		startPosition = new(boundPosition.X + margin, boundPosition.Y - margin);
		toX = new(startPosition.X + containerSideLength - margin, startPosition.Y);
		toY = new(startPosition.X, startPosition.Y - containerSideLength + margin);
		QueueRedraw();
	}

	private void DrawArrow(Vector2 startingPoint, Vector2 endingPoint)
	{
		DrawLine(startingPoint, endingPoint, color, width);

		float arrowSize = 20f;
		float flatness = 0.5f;

		Vector2 direction = (endingPoint - startingPoint).Normalized();

		Vector2 side1 = new Vector2(-direction.Y, direction.X);
		Vector2 side2 = new Vector2(direction.Y, -direction.X);

		Vector2 e1 = endingPoint + side1 * arrowSize * flatness;
		Vector2 e2 = endingPoint + side2 * arrowSize * flatness;

		Vector2 p1 = e1 - direction * arrowSize;
		Vector2 p2 = e2 - direction * arrowSize;

		DrawPolygon([endingPoint, p1, p2], [color]);

		DrawLine(endingPoint, p1, color, width);
		DrawLine(endingPoint, p2, color, width);
	}

	private void DrawScaleLines(int interval)
	{
		int scaleLineWidth = 3;
		float yPos = startPosition.Y;
		while (yPos > toY.Y)
		{
			DrawLine(new Vector2(startPosition.X - scaleLineWidth, yPos), new Vector2(startPosition.X + scaleLineWidth, yPos), color, width);
			yPos -= interval;
		}
		float xPos = startPosition.X;
		while (xPos < toX.X)
		{
			DrawLine(new Vector2(xPos, startPosition.Y - scaleLineWidth), new Vector2(xPos, startPosition.Y + scaleLineWidth), color, width);
			xPos += interval;
		}
	}

	public static Axises Instance
	{
		get => instance ??= new();
	}
}