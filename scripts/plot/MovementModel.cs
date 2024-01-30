using System;
using System.Linq;
using Godot;
using org.mariuszgromada.math.mxparser;

namespace GraphGame;

public partial class MovementModel
{
    private static MovementModel instance;
    private string mathExp;
    private static float _increment = 0.1f;
    private float xBorder;

    public static int DigitsNumber
    {
        get => _increment.ToString(System.Globalization.CultureInfo.InvariantCulture)
            .SkipWhile(c => c != '.')
            .Skip(1)
            .Count();
    }

    private int N = 0;

    private float Xn = 0;

    private Argument x = new("x");
    private Argument y;

    public MovementModel(string mathExp, float increment = 0.1f, float xBorder = 0f)
    {
        this.mathExp = mathExp;
        _increment = increment;
        this.xBorder = xBorder;
        Xn = xBorder;
        y = new(mathExp, x);
        instance = this;
    }

    public Vector2 CalculatePosition(int n)
    {
        Xn += N == n - 1 ? _increment : _increment * n;
        N = n;
        x.setArgumentValue(Xn);
        return new(
            MathF.Round((float)x.getArgumentValue(), DigitsNumber),
            MathF.Round((float)y.getArgumentValue(), DigitsNumber)
            );
    }

    public float Increment
    {
        get => _increment;
        set => _increment = value;
    }
    public float XBorder
    {
        set
        {
            xBorder = value;
            Xn = xBorder;
        }
    }
}