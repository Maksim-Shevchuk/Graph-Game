using Godot;
using System;

public partial class MainMenu : Control
{
	[Export] PackedScene packedScene;
	private void OnPlayButtonPressed()
	{
		GetTree().ChangeSceneToPacked(packedScene);
	}

	private void OnOptionsPressed()
	{

	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}
