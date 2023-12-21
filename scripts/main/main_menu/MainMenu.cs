using Godot;

public partial class MainMenu : Control
{
	[Export] private SceneNamesEnum sceneNamesEnum;

	private void OnPlayButtonPressed()
	{
		SceneManager.Instance.ChangeScene(sceneNamesEnum);
	}

	private void OnOptionsPressed()
	{

	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}
