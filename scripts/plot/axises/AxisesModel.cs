using System;
using Godot;

namespace GraphGame;

public partial class AxisesModel
{
    public event Action ModelUpadated;
    private int margin;
    private int interval;
    private Vector2 startPosition;
    private Vector2 toX;
    private Vector2 toY;
    private  readonly Vector2 boundPosition;
    private  readonly int containerSideLength;

    public AxisesModel(int margin, int interval) {
        boundPosition = new(510, 95);
        containerSideLength = 900 - 10;
        this.margin = margin;
        this.interval = interval;
        UpdateFields();
        startPosition = new(boundPosition.X + margin, boundPosition.Y - margin);
        toX = new(startPosition.X + containerSideLength - margin, startPosition.Y);
        toY = new(startPosition.X, startPosition.Y - containerSideLength + margin);
        // ModelUpadated?.Invoke();
     }

    public void Init(int margin, int interval)
    {
        this.margin = margin;
        this.interval = interval;
        UpdateFields();
        ModelUpadated?.Invoke();
    }

    private void UpdateFields()
    {
        startPosition = new(boundPosition.X + margin, boundPosition.Y - margin);
        toX = new(startPosition.X + containerSideLength - margin, startPosition.Y);
        toY = new(startPosition.X, startPosition.Y - containerSideLength + margin);
    }

    public int Margin { get => margin; }
    public int Interval { get => interval; }
    public Vector2 StartPosition { get => startPosition; }
    public Vector2 ToX { get => toX; }
    public Vector2 ToY { get => toY; }

}