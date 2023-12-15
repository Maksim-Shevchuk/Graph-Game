using Godot;
using GraphGame;

public partial class ControlLayer : CanvasLayer
{
	[Export] private ControlScene controlScene;
	private static ControlLayer instance;
	private ControlLayer() { }

	public void Init(bool extraInputEnabled)
	{
		controlScene.Init(extraInputEnabled);
	}
	
	public static ControlLayer Instance { get => instance ??= new(); }
}