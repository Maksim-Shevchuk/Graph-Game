using System;
using System.IO;
using Godot;

public class CoordsUtils
{
    private static int margin;
    private static int interval;
    private static readonly Vector2 gameAreaRect = new(525, 945);
    private static Vector2 realGameRect;

    public static void Init(int _margin, int _interval)
    {
        margin = _margin;
        realGameRect = new(gameAreaRect.X + margin, gameAreaRect.Y - margin);
        interval = _interval;
        PathBuilder.Instance.Init();
    }

    public static Vector2 ToWorldCoords(Vector2 globalCoords)
    {
        return new(
            MathF.Round((globalCoords.X - gameAreaRect.X - margin) / interval, 5),
            MathF.Round((gameAreaRect.Y - margin - globalCoords.Y) / interval, 5)
            );
    }

    public static Vector2 ToScreenCoords(Vector2 relativeCoords)
    {
        return new(
            MathF.Round(relativeCoords.X * interval + realGameRect.X, 5),
            MathF.Round(realGameRect.Y - relativeCoords.Y * interval, 5)
        );
    }

    public static int Margin
    {
        get => margin;
        set => margin = value;
    }

    public static int Interval
    {
        get => interval;
        set => interval = value;
    }
}