using Godot;
using GraphGame;
using System;

public partial class GraphContainer : PanelContainer
{
	[Export] private PanelContainer levelEndedContainer;
	[Export] private Label winOrLooseLabel;
	[Export] private Button nextLevelButton;
	[Export] private Label nextLevelLabel;
	// [Export] private PackedScene mainScene;
	[Export] private SceneNamesEnum sceneNamesEnum;
	[Export] private PanelContainer HelpPopUpContainer;

	private GraphContainerModel model = GraphContainerModel.Instance;
	private GraphContainerController controller = GraphContainerController.Instance;

	public override void _Ready()
	{
		levelEndedContainer.Visible = false;
		model.ShowLevelEndMenu += ChangeVisibilityLevelEndedContainer;
	}

	public override void _ExitTree()
	{
		model.ShowLevelEndMenu -= ChangeVisibilityLevelEndedContainer;
	}

	public void OnRestartPressed()
	{
		controller.OnRestartPressed();
	}

	public void OnHomePressed()
	{
		SceneManager.Instance.ChangeScene(sceneNamesEnum);
		// GetTree().ChangeSceneToPacked(mainScene);
		// GetTree().ChangeSceneToFile("res://main/main.tscn");
	}

	public void OnNextPressed()
	{
		controller.OnNextPressed();
	}

	private void ChangeVisibilityLevelEndedContainer(bool isWin)
	{
		HelpPopUpContainer.Visible = false;
		nextLevelButton.Disabled = !isWin;
		if (!isWin || !model.IsNextLevelAvilable())
		{
			nextLevelLabel.Modulate = Colors.Gray;
		}
		levelEndedContainer.Visible = true;
		winOrLooseLabel.Text = isWin ? "You win!" : "You lose";
	}
}
