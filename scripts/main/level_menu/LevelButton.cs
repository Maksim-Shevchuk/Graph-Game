using Godot;
using GraphGame;

public partial class LevelButton : Button
{
	[Export] private Label label;
	[Export] private PackedScene packedScene;
	
	private void OnPressed()
	{
		Game game = packedScene.Instantiate<Game>();
		game.Level = int.Parse(label.Text);
		GetTree().ChangeSceneToPacked(packedScene);
	}

	public Label Label
	{
		get => label;
		set => label = value;
	}
}
