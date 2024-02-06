using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Godot;
using GraphGame;

public partial class PathBuilderModel
{
    public event Action<Queue<Vector2>> PathBuilt;
    private static PathBuilderModel instance;
    private MovementModel movementModel = null;
    private Rect2 expandedRect;
    private Queue<Vector2> path;

    public void Init()
    {
        path = [];
        Vector2 leftUpperCorner = new(450, 35);
        float rectLength = 985;
        expandedRect = new Rect2(leftUpperCorner, new Vector2(rectLength + 55, rectLength));
    }

    private void BuildPath()
    {
        int i = 0;
        path = new Queue<Vector2>();
        bool noPointOutsideRect = true;
        while (noPointOutsideRect)
        {
            Vector2 point = CoordsUtils.ToScreenCoords(movementModel.CalculatePosition(i));
            if (HasPoint(point))
            {
                path.Enqueue(point);
                i++;
            }
            else
            {
                noPointOutsideRect = false;
            }
        }
        PathBuilt?.Invoke(path);
    }

    public void HidePath()
    {
        path = new Queue<Vector2>();
        PathBuilt?.Invoke(path);
    }

    public bool HasPoint(Vector2 position)
    {
        return expandedRect.HasPoint(position);
    }

    private PathBuilderModel() { }

    public static PathBuilderModel Instance
    {
        get => instance ??= new();
    }

    public MovementModel MovementModel
    {
        get => movementModel;
        set
        {
            movementModel = value;
            BuildPath();
        }
    }
}