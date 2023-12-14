using Godot;
using GraphGame;

public partial class ControlLayer : CanvasLayer
{
	[Export] private ControlScene controlScene;
	private static ControlLayer instance;
	private ControlLayer() { }

	public void Init()
	{
		controlScene.Init();
	}
	
	public static ControlLayer Instance { get => instance ??= new(); }
}