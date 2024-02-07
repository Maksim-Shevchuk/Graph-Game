using Godot;
using GraphGame;

public partial class MainMenu : Control
{
	[Export] private SceneNamesEnum sceneNamesEnum;
	[Export] private PanelContainer settingsContainer;
	[Export] private VBoxContainer mainMenuButtonsContainer;
	[Export] private CheckBox easyModeCheckBox;

	private GameState gameState;

	public override void _Ready()
	{
		gameState = JsonSerializerUtils.DeserializeGameState();
		easyModeCheckBox.ButtonPressed = gameState.IsEasyModeEnabled;
	}
	private void OnPlayButtonPressed()
	{
		SceneManager.Instance.ChangeScene(sceneNamesEnum);
	}

	private void OnOptionsPressed()
	{
		settingsContainer.Visible = true;
		mainMenuButtonsContainer.Visible = false;
	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}

	private void OnCloseButtonPressed()
	{
		settingsContainer.Visible = false;
		mainMenuButtonsContainer.Visible = true;
	}

	private void OnCheckBoxPressed()
	{
		if (gameState.IsEasyModeEnabled != easyModeCheckBox.ButtonPressed)
		{
			gameState.IsEasyModeEnabled = easyModeCheckBox.ButtonPressed;
			JsonSerializerUtils.SerializeGameState(gameState);
		}
	}
}
