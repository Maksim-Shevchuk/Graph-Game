using Godot;
using GraphGame;

using System.Collections.Generic;

public partial class PlotLayer : CanvasLayer
{
	private CheckPointStorageModel checkPointStorageModel = CheckPointStorageModel.Instance;
	private Axises axises = Axises.Instance;

	public void Init(int margin, int interval, List<Vector2> checkPointCoords, List<Vector2> obstacleCoords)
	{
		checkPointStorageModel.Init(checkPointCoords, obstacleCoords);
		axises.Init(margin, interval);
	}
}
