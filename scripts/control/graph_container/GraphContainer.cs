using Godot;
using System;

public partial class GraphContainer : PanelContainer
{
	[Export] public PanelContainer levelEndedContainer;
	[Export] public Label winOrLooseLabel;
	private GraphContainerModel model = GraphContainerModel.Instance;
	private GraphContainerController controller = GraphContainerController.Instance;

	public override void _Ready()
	{
		levelEndedContainer.Visible = false;
		model.ShowLevelEndMenu += ChangeVisibilityLevelEndedContainer;
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
		levelEndedContainer.Visible = true;
		winOrLooseLabel.Text = isWin? "You win!" : "You loose";
    }
}
