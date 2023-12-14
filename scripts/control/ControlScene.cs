using System.Security.AccessControl;
using Godot;

namespace GraphGame;

public partial class ControlScene : Control
{
	[Export] private PlayArea playArea;
	private static ControlScene instance;
	private ControlScene() { }
	private PlayAreaModel playAreaModel = PlayAreaModel.Instance;

	public void Init()
	{
		playAreaModel.Init();
	}

	public override void _UnhandledInput(InputEvent @event) { }

	public static ControlScene Instance { get => instance ??= new(); }
}