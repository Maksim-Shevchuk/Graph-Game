using Godot;
using GraphGame;
using System;
using System.Text.RegularExpressions;

public partial class PlayArea : VBoxContainer
{
	[Export] private LineEdit functionLineEdit;
	[Export] private HBoxContainer expandedInput;
	[Export] private LineEdit xZeroLineEdit;
	[Export] private LineEdit deltaLineEdit;
	[Export] private Button runButton;
	[Export] private PanelContainer HelpPopUpContainer;

	private static PlayArea instance;
	private PlayAreaModel model = PlayAreaModel.Instance;
	private PlayAreaController controller = PlayAreaController.Instance;
	private Ship shipView = Ship.Instance;

	private PlayArea() { }

	public override void _Ready()
	{
		functionLineEdit.GrabFocus();
		expandedInput.Visible = false;
		HelpPopUpContainer.Visible = false;
		model.ChangeVisibilityExpandedInput += ChangeVisibilityExpandedInput;
	}

	public override void _ExitTree()
	{
		model.ChangeVisibilityExpandedInput -= ChangeVisibilityExpandedInput;
	}

	private void OnRunButtonPressed()
	{
		if (!string.IsNullOrEmpty(functionLineEdit.Text))
		{
			runButton.Disabled = true;
			Regex functionRegex = new("^y=x?.+");
			string function = functionLineEdit.Text.Replace("\\s", "").ToLower();
			if (functionRegex.Matches(function).Count > 0)
			{
				float xZero = string.IsNullOrEmpty(xZeroLineEdit.Text) ? float.NaN : float.Parse(xZeroLineEdit.Text.Replace(".", ","));
				float delta = string.IsNullOrEmpty(deltaLineEdit.Text) ? float.NaN : float.Parse(deltaLineEdit.Text.Replace(".", ","));
				controller.HandleRunButtonPressed(function, xZero, delta);
			}
		}
	}

	private void OnHelpButtonPressed()
	{
		HelpPopUpContainer.Visible = !HelpPopUpContainer.Visible;
	}

	private void OnClosePopUpButtonPressed()
	{
		HelpPopUpContainer.Visible = false;
	}

	private void ChangeVisibilityExpandedInput(bool isExpandedInputVisible)
	{
		expandedInput.Visible = isExpandedInputVisible;
	}

	public static PlayArea Instance { get => instance ??= new(); }
}
