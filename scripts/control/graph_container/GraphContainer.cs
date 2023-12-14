using Godot;
using GraphGame;
using System;

public partial class GraphContainer : PanelContainer
{
	[Export] private PanelContainer levelEndedContainer;
	[Export] private Label winOrLooseLabel;
	[Export] private Button nextLevelButton;
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

	public void OnNextPressed()
	{
		controller.OnNextPressed();
	}

	private void ChangeVisibilityLevelEndedContainer(bool isWin)
	{	
		nextLevelButton.Visible = isWin;
		levelEndedContainer.Visible = true;
		winOrLooseLabel.Text = isWin ? "You win!" : "You loose";
	}
}
