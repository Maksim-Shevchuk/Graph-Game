using Godot;
using System;

public partial class LevelMenu : Control
{
	[Export] private PackedScene buttonPackedScene;
	[Export] private GridContainer levelsContainer;

	private LevelMenuModel levelMenuModel = LevelMenuModel.Instance;

	public override void _Ready()
	{
		levelMenuModel.Init();
		levelMenuModel.ModelUpdated += AddLevelButtons;
		AddLevelButtons(5);
	}

	public override void _ExitTree()
	{
		levelMenuModel.ModelUpdated -= AddLevelButtons;
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

}
