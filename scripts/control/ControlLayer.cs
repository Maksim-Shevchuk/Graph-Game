using Godot;
using GraphGame;

public partial class ControlLayer : CanvasLayer
{
	[Export] private ControlScene controlScene; 

	public  void Init()
	{
		controlScene.Init();
	}
}