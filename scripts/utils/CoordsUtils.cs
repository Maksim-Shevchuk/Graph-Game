using Godot;

public class CoordsUtils
{
    private static int margin;
    private static int interval;
    private static readonly Vector2 gameAreaRect = new(510, 935);
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

    // public static Vector2 Calculate(string mathExp)
    // {
    //     Argument x = new("x");
    //     Argument y = new(mathExp, x);
    // }

    // public static Queue<Vector2> FormCoordsList(string mathExp)
    // {
    //     float scalesAmount = (890 - margin) / (float)interval + 1;
    //     Queue<Vector2> vectors = [];
    //     Argument x = new("x");
    //     Argument y = new(mathExp, x);

    //     bool hasPointInGameArea = true;
    //     float i = 0f;
    //     while (hasPointInGameArea && i < scalesAmount)
    //     {
    //         x.setArgumentValue(i);
    //         Vector2 relativeCoords = new(
    //             (float)x.getArgumentValue(),
    //             (float)y.getArgumentValue()
    //         );
    //         // bool hasPointInGameArea = relativeCoords.X > scalesAmount || relativeCoords.Y > scalesAmount;
    //         if (relativeCoords.X <= scalesAmount && relativeCoords.Y <= scalesAmount)
    //         {
    //             vectors.Enqueue(ToScreenCoords(relativeCoords));
    //             i += 1f;
    //         }
    //         else
    //         {
    //             hasPointInGameArea = false;
    //         }
    //     }
    //     return vectors;
    // }

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