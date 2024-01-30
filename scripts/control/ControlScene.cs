using System.Security.AccessControl;
using Godot;

namespace GraphGame;

public partial class ControlScene : Control
{
	[Export] private PlayArea playArea;
	[Export] private TextureRect textureRect;
	[Export] private Texture2D singlLineEditRect;
	[Export] private Texture2D multipleLineEditRect;
	private static ControlScene instance;
	
	private ControlScene() { }
	private PlayAreaModel playAreaModel = PlayAreaModel.Instance;

	public void Init(bool extraInputEnabled)
	{
		if (extraInputEnabled)
		{
			textureRect.Texture = multipleLineEditRect;
		}
		else
		{
			textureRect.Texture = singlLineEditRect;
		}
		playAreaModel.Init(extraInputEnabled);
	}

	public override void _UnhandledInput(InputEvent @event) { }

	public static ControlScene Instance { get => instance ??= new(); }
}