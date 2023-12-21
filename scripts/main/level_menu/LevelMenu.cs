using Godot;
using GraphGame;
using System;
using System.IO;

public partial class LevelMenu : Control
{
	[Export] private PackedScene buttonPackedScene;
	[Export] private GridContainer levelsContainer;
	[Export] private SceneNamesEnum sceneNamesEnum;

	[Export] private PackedScene levelPackedScene;

	private LevelMenuModel levelMenuModel = LevelMenuModel.Instance;
	private int count => Directory.GetFiles(@"scripts\level\json").Length;

	public override void _Ready()
	{
		// levelMenuModel.Init();
		levelMenuModel.ModelUpdated += AddLevelButtons;
		levelMenuModel.RunCurrentLevel += RunSelectedLevel;
		AddLevelButtons(count);
	}

	public override void _ExitTree()
	{
		levelMenuModel.ModelUpdated -= AddLevelButtons;
		levelMenuModel.RunCurrentLevel -= RunSelectedLevel;
	}

	private void AddLevelButtons(int levelsAmount)
	{
		for (int i = 1; i <= levelsAmount; i++)
		{
			LevelButton levelButton = buttonPackedScene.Instantiate<LevelButton>();
			levelButton.Label.Text = Convert.ToString(i);
			levelsContainer.AddChild(levelButton);
		}
	}

	public void RunSelectedLevel(int level)
	{
		Game game = levelPackedScene.Instantiate<Game>();
		game.Level = level;

		GetTree().ChangeSceneToPacked(levelPackedScene);
		
		// Game.Instance.Level = level;
		// SceneManager.Instance.ChangeScene(sceneNamesEnum);
	}
}
