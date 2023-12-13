using Godot;
using org.mariuszgromada.math.mxparser;

namespace GraphGame;

public partial class MovementModel
{
    private string mathExp;
    private float increment;
    private float xBorder;

    private int N = 0;
    
    private float Xn = 0;

    private Argument x = new("x");
    private Argument y;

    public MovementModel(string mathExp, float increment =0.1f, float xBorder = 0f)
    {
        this.mathExp = mathExp;
        this.increment = increment;
        this.xBorder = xBorder;
        Xn = xBorder;
        y = new(mathExp, x);
    }

    public Vector2 CalculatePosition(int n)
    {
        Xn += N == n - 1 ? increment : increment * n;
        N = n;
        x.setArgumentValue(Xn);
        return new((float)x.getArgumentValue(), (float)y.getArgumentValue());
    }
}