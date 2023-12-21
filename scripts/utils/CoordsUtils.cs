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
    }

    public static Vector2 ToWorldCoords(Vector2 globalCoords)
    {
        return new((globalCoords.X - gameAreaRect.X - margin) / interval,
            (gameAreaRect.Y - margin - globalCoords.Y) / interval);
    }

    public static Vector2 ToScreenCoords(Vector2 relativeCoords)
    {
        return new(relativeCoords.X * interval + realGameRect.X,
            realGameRect.Y - relativeCoords.Y * interval);
    }

    public static int Margin
    {
        get => margin;
        set => margin = value;
    }

    public static
     int Interval
    {
        get => interval;
        set => interval = value;
    }
}