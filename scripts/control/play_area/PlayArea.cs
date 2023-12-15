using Godot;
using GraphGame;
using System;
using System.Text.RegularExpressions;

public partial class PlayArea : VBoxContainer
{
	[Export] private LineEdit functionLineEdit;
	[Export] private HBoxContainer expandedInput;
	private static PlayArea instance;
	private PlayAreaModel model = PlayAreaModel.Instance;
	private PlayAreaController controller = PlayAreaController.Instance;
	private Ship shipView = Ship.Instance;


	private PlayArea() { }

	public override void _Ready()
	{
		functionLineEdit.GrabFocus();
		expandedInput.Visible = false;
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
			Regex functionRegex = new("^y=x?.+");
			string text = functionLineEdit.Text.Replace("\\s", "").ToLower();
			if (functionRegex.Matches(text).Count > 0)
			{
				controller.HandleRunButtonPressed(text);
			}
		}
	}

	private void ChangeVisibilityExpandedInput(bool isExpandedInputVisible)
	{
		expandedInput.Visible = isExpandedInputVisible;
	}

	public static PlayArea Instance { get => instance ??= new(); }
}
