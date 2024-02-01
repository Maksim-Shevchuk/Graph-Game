using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GraphGame;

public partial class ShipModel
{
    private static ShipModel instance;
    private GraphContainerModel graphContainerModel = GraphContainerModel.Instance;
    private CheckPointStorageModel checkPointStorageModel = CheckPointStorageModel.Instance;
    private MovementModel movementModel;
    private Queue<Vector2> path;

    public event Action<Vector2> ModelUpdated;
    public event Action<Queue<Vector2>> PathBuilt;
    public event Action ModelDestroyed;
    private ShipModel() { }

    public void Init(Vector2 startPosition)
    {
        path = [];
        ModelUpdated?.Invoke(startPosition);
    }

    public bool CheckAvailabilityInPath(Vector2 position)
    {
        return path.Contains(position);
    }

    private void FindPath()
    {
        int i = 1;
        bool noPointOutsideSquare = true;
        while (noPointOutsideSquare)
        {
            Vector2 point = movementModel.CalculatePosition(i);
            if (graphContainerModel.HasPoint(point))
            {
                path.Enqueue(point);
                i++;
            }
            else { noPointOutsideSquare = false; }
        }
        
        PathBuilt?.Invoke(new Queue<Vector2>(path));
    }

    public bool ContainsInPath(Vector2 position)
    {
        ModelDestroyed?.Invoke();
        return path.Contains(position);
    }

    public bool JustContainsInPath(Vector2 pos) => path.Contains(pos);

    public void MovementStopped()
    {
        checkPointStorageModel.CheckCoordsCoincidence(path.ToList());
    }

    public static ShipModel Instance { get => instance ??= new(); }
    public MovementModel MovementModel
    {
        get => movementModel;
        set
        {
            movementModel = value;
            ModelUpdated?.Invoke(movementModel.CalculatePosition(0));
            FindPath();
        }
    }
}